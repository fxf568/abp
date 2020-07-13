using Volo.Abp;
using Volo.Abp.Testing;

namespace Skuo.IdentityServer.Test
{
    public class SkuoIdentityServerDomainTestBase : AbpIntegratedTest<SkuoIdentityServerDomainTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
