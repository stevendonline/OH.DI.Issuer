using OH.DI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OH.DI.EntityFrameworkCore.Identity.Cosmos.Extensions;
using Microsoft.AspNetCore.Identity;

namespace OH.DI.Infrastructure;

public static class StartupSetup
{
  //public static void AddDbContext(this IServiceCollection services, string connectionString) =>
  //    services.AddDbContext<AppDbContext>(options =>
  //        options.UseSqlite(connectionString)); // will be created in web DigitalCredential root
  //static string _connStr = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
  //static string _dbName = "didb";
  public static void AddCosmosDbContext(this IServiceCollection services, IConfiguration config)
  {
    var dbConf = config.Get<CosmosSettings>();
    //services.AddDbContext<AppDbContext>(options =>
    //  {
    //    options.UseCosmos(dbConf.EndPoint, dbConf.AccessKey, "didb");
    //    options.EnableSensitiveDataLogging();
    //  }
    //);

    services.AddCosmosIdentity<AppDbContext, ApplicationUser, IdentityRole>(
      idoptions => {
        idoptions.User.RequireUniqueEmail = false;
      },
      dboptions => dboptions.UseCosmos(dbConf.EndPoint, dbConf.AccessKey, "didb"),
      addDefaultTokenProviders: true)
      .AddDefaultUI();
    
  }
}


