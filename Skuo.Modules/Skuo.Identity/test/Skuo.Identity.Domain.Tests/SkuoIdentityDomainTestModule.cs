using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Skuo.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp;

namespace Skuo.Identity.Test
{
    [DependsOn(
        typeof(SkuoIdentityEntityFrameworkCoreTestModule),
        typeof(SkuoIdentityTestBaseModule),
        typeof(Skuo.Snowflake.SkuoSnowflakeModule)
        )]
    public class SkuoIdentityDomainTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<IdentityUser>();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(ApplicationInitializationContext context)
        {
            //using (var scope = context.ServiceProvider.CreateScope())
            //{
            //    AsyncHelper.RunSync(() => scope.ServiceProvider
            //        .GetRequiredService<TestPermissionDataBuilder>()
            //        .Build());
            //}
        }
    }
}
