using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Skuo.Users.EntityFrameworkCore;

namespace Skuo.Identity.EntityFrameworkCore
{
    [DependsOn(
        typeof(SkuoIdentityDomainModule), 
        typeof(SkuoUsersEntityFrameworkCoreModule))]
    public class SkuoIdentityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
                options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
                options.AddRepository<IdentityClaimType, EfCoreIdentityClaimTypeRepository>();
            });
        }
    }
}
