using Volo.Abp.Modularity;

namespace Skuo.Identity.Test
{
    [DependsOn(
        typeof(SkuoIdentityApplicationModule), 
        typeof(SkuoIdentityDomainTestModule)
        )]
    public class SkuoIdentityApplicationTestModule : AbpModule
    {

    }
}
