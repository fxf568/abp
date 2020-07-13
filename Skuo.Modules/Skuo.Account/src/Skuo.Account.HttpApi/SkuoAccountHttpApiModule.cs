using Localization.Resources.AbpUi;
using Skuo.Account.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Skuo.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Skuo.Account
{
    [DependsOn(
        typeof(SkuoAccountApplicationContractsModule),
        typeof(SkuoIdentityHttpApiModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class SkuoAccountHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SkuoAccountHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}