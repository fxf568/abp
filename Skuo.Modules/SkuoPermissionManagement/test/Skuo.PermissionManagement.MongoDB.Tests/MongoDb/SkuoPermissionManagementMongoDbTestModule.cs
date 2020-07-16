using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Skuo.PermissionManagement.MongoDB
{
    [DependsOn(
        typeof(SkuoPermissionManagementMongoDbModule),
        typeof(SkuoPermissionManagementTestBaseModule))]
    public class SkuoPermissionManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                    "Db_" +									
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
