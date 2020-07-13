using Volo.Abp;
using Volo.Abp.Testing;

namespace Skuo.IdentityServer.Tests
{
    public class SkuoIdentityServerTestBase : AbpIntegratedTest<SkuoIdentityServerTestEntityFrameworkCoreModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
