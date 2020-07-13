using Volo.Abp.AspNetCore.Mvc;
using Skuo.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;

namespace Skuo.Identity
{
    [DependsOn(typeof(SkuoIdentityApplicationContractsModule), typeof(AbpAspNetCoreMvcModule))]
    public class SkuoIdentityHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SkuoIdentityHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<IdentityResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}