using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using OrganizationService.Localization;

namespace Skuo.Organization
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class OrganizationDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<OrganizationServiceResource>("en");
            });
        }
    }
}
