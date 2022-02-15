//using IdentityServer4.EntityFramework.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OH.DI.EntityFrameworkCore.Identity.Cosmos.Extensions;

namespace OH.DI.EntityFrameworkCore.Identity.Cosmos
{
    public class CosmosIdentityDbContext<TUserEntity> : ApiAuthorizationDbContext<TUserEntity> where TUserEntity : IdentityUser
    {
        public CosmosIdentityDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyIdentityMappings<TUserEntity>();
        }
    }
}
