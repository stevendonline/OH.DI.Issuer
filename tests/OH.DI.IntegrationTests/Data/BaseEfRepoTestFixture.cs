﻿using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace OH.DI.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
  protected AppDbContext _dbContext;

  protected BaseEfRepoTestFixture()
  {
    var options = CreateNewContextOptions();
    var mockMediator = new Mock<IMediator>();

    _dbContext = new AppDbContext(options, null, mockMediator.Object);
  }

  protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<AppDbContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected EfRepository<DigitalCredential> GetRepository()
  {
    return new EfRepository<DigitalCredential>(_dbContext);
  }
}
