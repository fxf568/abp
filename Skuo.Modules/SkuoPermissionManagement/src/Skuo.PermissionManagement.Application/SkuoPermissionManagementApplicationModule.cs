using Volo.Abp.Modularity;

namespace Skuo.PermissionManagement
{
    [DependsOn(
        typeof(SkuoPermissionManagementDomainModule), 
        typeof(SkuoPermissionManagementApplicationContractsModule)
        )]
    public class SkuoPermissionManagementApplicationModule : AbpModule
    {
        
    }
}
