using Ardalis.EFCore.Extensions;
using OH.DI.Core.ProjectAggregate;
using OH.DI.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OH.DI.EntityFrameworkCore.Identity.Cosmos;
using Microsoft.AspNetCore.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace OH.DI.Infrastructure.Data;

public class AppDbContext : CosmosIdentityDbContext<ApplicationUser>
{
  private readonly IMediator? _mediator;

  //public AppDbContext(DbContextOptions options) : base(options)
  //{
  //}

  public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IOptions<OperationalStoreOptions> options, IMediator? mediator)
      : base(dbContextOptions, options)
  {    
    _mediator = mediator;
  }

  //public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  public DbSet<ToDoItem> ToDoItems { get; set; }
  //public DbSet<Project> Projects => Set<Project>();
  public DbSet<Project> Projects { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

    // alternately this is built-in to EF Core 2.2
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_mediator == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
        .Select(e => e.Entity)
        .Where(e => e.Events.Any())
        .ToArray();

    foreach (var entity in entitiesWithEvents)
    {
      var events = entity.Events.ToArray();
      entity.Events.Clear();
      foreach (var domainEvent in events)
      {
        await _mediator.Publish(domainEvent).ConfigureAwait(false);
      }
    }

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
