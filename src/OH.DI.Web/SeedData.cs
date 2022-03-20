using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OH.DI.Web;

public static class SeedData
{
  public static readonly string proj1 = 1.ToString();
  public static readonly DigitalCredential TestDigitalCredential1 = new DigitalCredential(proj1, "Test DigitalCredential");
  public static readonly AssuredClaim ToDoItem1 = new AssuredClaim
  {
    Id = Guid.NewGuid().ToString(),
    Name = "Get Sample Working",
    Description = "Try to get the sample to build."
  };
  public static readonly AssuredClaim ToDoItem2 = new AssuredClaim
  {
    Id = Guid.NewGuid().ToString(),
    Name = "Review Solution",
    Description = "Review the different DigitalCredentials in the solution and how they relate to one another."
  };
  public static readonly AssuredClaim ToDoItem3 = new AssuredClaim
  {
    Id = Guid.NewGuid().ToString(),
    Name = "Run and Review Tests",
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
    foreach (var item in dbContext.DigitalCredentials)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestDigitalCredential1.AddItem(ToDoItem1);
    TestDigitalCredential1.AddItem(ToDoItem2);
    TestDigitalCredential1.AddItem(ToDoItem3);
    dbContext.DigitalCredentials.Add(TestDigitalCredential1);

    dbContext.SaveChanges();
  }
}
