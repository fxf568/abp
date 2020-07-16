using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Skuo.PermissionManagement.MongoDB
{
    [DependsOn(
        typeof(SkuoPermissionManagementDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class SkuoPermissionManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<PermissionManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IPermissionManagementMongoDbContext>();

                options.AddRepository<PermissionGrant, MongoPermissionGrantRepository>();
            });
        }
    }
}
