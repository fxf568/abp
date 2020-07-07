using OrganizationService.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace Skuo.Organization
{
    [DependsOn(
        typeof(OrganizationDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class OrganizationApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<OrganizationApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<OrganizationServiceResource>()
                    .AddVirtualJson("/OrganizationService/Localization/ApplicationContracts");
            });
        }
    }
}
