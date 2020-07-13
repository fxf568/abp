using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Skuo.Users;

namespace Skuo.Identity
{
    [DependsOn(
        typeof(SkuoIdentityDomainSharedModule),
        typeof(SkuoUsersAbstractionModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpDddApplicationModule)
        )]
    public class SkuoIdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}