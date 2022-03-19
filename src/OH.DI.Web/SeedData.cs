﻿using OH.DI.Core.ProjectAggregate;
using OH.DI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OH.DI.Web;

public static class SeedData
{
  public static readonly string proj1 = 1.ToString();
  public static readonly DigitalCredential TestProject1 = new DigitalCredential(proj1, "Test Project");
  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Id = Guid.NewGuid().ToString(),
    Title = "Get Sample Working",
    Description = "Try to get the sample to build."
  };
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Id = Guid.NewGuid().ToString(),
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another."
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Id = Guid.NewGuid().ToString(),
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing."
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null, null))
    {
      // Look for any TODO items.
      if (dbContext.ToDoItems.Count() > 0)
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);


    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Projects)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestProject1.AddItem(ToDoItem1);
    TestProject1.AddItem(ToDoItem2);
    TestProject1.AddItem(ToDoItem3);
    dbContext.Projects.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
