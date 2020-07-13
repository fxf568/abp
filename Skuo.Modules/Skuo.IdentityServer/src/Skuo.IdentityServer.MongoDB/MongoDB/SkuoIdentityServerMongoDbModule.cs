using Microsoft.Extensions.DependencyInjection;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.Grants;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using ApiResource = Skuo.IdentityServer.ApiResources.ApiResource;
using Client = Skuo.IdentityServer.Clients.Client;
using IdentityResource = Skuo.IdentityServer.IdentityResources.IdentityResource;

namespace Skuo.IdentityServer.MongoDB
{
    [DependsOn(
        typeof(SkuoIdentityServerDomainModule),
        typeof(AbpMongoDbModule)
    )]
    public class SkuoIdentityServerMongoDbModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<IIdentityServerBuilder>(
                builder =>
                {
                    builder.AddAbpStores();
                }
            );
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<SkuoIdentityServerMongoDbContext>(options =>
            {
                options.AddRepository<ApiResource, MongoApiResourceRepository>();
                options.AddRepository<IdentityResource, MongoIdentityResourceRepository>();
                options.AddRepository<Client, MongoClientRepository>();
                options.AddRepository<PersistedGrant, MongoPersistentGrantRepository>();
                options.AddRepository<DeviceFlowCodes, MongoDeviceFlowCodesRepository>();
            });
        }
    }
}
