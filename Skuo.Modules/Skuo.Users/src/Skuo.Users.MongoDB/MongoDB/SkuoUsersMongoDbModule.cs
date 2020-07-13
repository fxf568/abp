using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Skuo.Users.MongoDB
{
    [DependsOn(
        typeof(SkuoUsersDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class SkuoUsersMongoDbModule : AbpModule
    {
        
    }
}
