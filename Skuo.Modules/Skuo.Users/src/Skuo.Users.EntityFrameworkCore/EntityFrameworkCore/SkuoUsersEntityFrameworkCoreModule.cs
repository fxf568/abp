using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Skuo.Users.EntityFrameworkCore
{
    [DependsOn(
        typeof(SkuoUsersDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class SkuoUsersEntityFrameworkCoreModule : AbpModule
    {
        
    }
}
