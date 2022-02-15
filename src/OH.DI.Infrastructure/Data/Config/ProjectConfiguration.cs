using OH.DI.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OH.DI.Infrastructure.Data.Config;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.ToContainer("Project");
    builder.HasPartitionKey(proj => proj.Id);
    builder.HasMany<ToDoItem>(todo => todo.Items).WithOne();

    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();
  }
}
