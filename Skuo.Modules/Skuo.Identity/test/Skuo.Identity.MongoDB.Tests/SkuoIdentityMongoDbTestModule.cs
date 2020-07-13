using Skuo.Identity.MongoDB;
using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Skuo.Identity.Test
{
    [DependsOn(
        typeof(SkuoIdentityTestBaseModule),
        typeof(SkuoIdentityMongoDbModule)
        )]
    public class SkuoIdentityMongoDbTestModule : AbpModule
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
