using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;

namespace Skuo.Identity.Test
{
    public abstract class SkuoIdentityTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
