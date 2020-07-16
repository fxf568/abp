using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Skuo.PermissionManagement
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(SkuoPermissionManagementDomainSharedModule))]
    public class SkuoPermissionManagementApplicationContractsModule : AbpModule
    {
        
    }
}
