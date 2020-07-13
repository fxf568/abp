using Skuo.IdentityServer.Tests;
using Volo.Abp.Modularity;

namespace Skuo.IdentityServer.Test
{
    [DependsOn(typeof(SkuoIdentityServerTestEntityFrameworkCoreModule))]
    public class SkuoIdentityServerDomainTestModule : AbpModule
    {

    }
}
