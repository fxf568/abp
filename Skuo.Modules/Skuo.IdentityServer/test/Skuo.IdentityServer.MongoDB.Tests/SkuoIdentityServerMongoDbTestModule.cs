using Skuo.Identity.MongoDB;
using Skuo.IdentityServer.MongoDB;
using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Skuo.IdentityServer.Test
{

    [DependsOn(
        typeof(SkuoIdentityServerTestBaseModule),
        typeof(SkuoIdentityServerMongoDbModule),
        typeof(SkuoIdentityMongoDbModule)
    )]
    public class SkuoIdentityServerMongoDbTestModule : AbpModule
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
