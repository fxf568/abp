using Volo.Abp;
using Volo.Abp.Testing;

namespace Skuo.Account.Test
{
    public class SkuoAccountApplicationTestBase : AbpIntegratedTest<SkuoAccountApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}