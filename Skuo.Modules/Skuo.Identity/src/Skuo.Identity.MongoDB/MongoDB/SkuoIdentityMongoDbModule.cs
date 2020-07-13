using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Skuo.Users.MongoDB;

namespace Skuo.Identity.MongoDB
{
    [DependsOn(
        typeof(SkuoIdentityDomainModule),
        typeof(SkuoUsersMongoDbModule)
        )]
    public class SkuoIdentityMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<SkuoIdentityMongoDbContext>(options =>
            {
                options.AddRepository<IdentityUser, MongoIdentityUserRepository>();
                options.AddRepository<IdentityRole, MongoIdentityRoleRepository>();
                options.AddRepository<IdentityClaimType, MongoIdentityRoleRepository>();
            });
        }
    }
}
