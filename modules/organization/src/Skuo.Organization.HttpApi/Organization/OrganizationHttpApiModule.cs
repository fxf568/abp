using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Skuo.Organization
{
    [DependsOn(
        typeof(OrganizationApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class OrganizationHttpApiModule : AbpModule
    {
        
    }
}
