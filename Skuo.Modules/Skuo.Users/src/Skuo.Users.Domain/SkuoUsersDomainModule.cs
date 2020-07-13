using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Skuo.Users
{
    [DependsOn(
        typeof(SkuoUsersDomainSharedModule),
        typeof(SkuoUsersAbstractionModule),
        typeof(AbpDddDomainModule)
        )]
    public class SkuoUsersDomainModule : AbpModule
    {
        
    }
}
