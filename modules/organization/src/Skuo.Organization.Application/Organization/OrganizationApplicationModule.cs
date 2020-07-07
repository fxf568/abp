using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Skuo.Organization
{
    [DependsOn(
        typeof(OrganizationDomainModule),
        typeof(OrganizationApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class OrganizationApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<OrganizationApplicationAutoMapperProfile>(validate: false);
            });
        }
    }
}
