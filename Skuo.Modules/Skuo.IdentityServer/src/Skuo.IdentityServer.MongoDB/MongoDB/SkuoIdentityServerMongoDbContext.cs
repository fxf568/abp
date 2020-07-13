using MongoDB.Driver;
using Volo.Abp.Data;
using Skuo.IdentityServer.ApiResources;
using Skuo.IdentityServer.Clients;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.Grants;
using Volo.Abp.MongoDB;
using IdentityResource = Skuo.IdentityServer.IdentityResources.IdentityResource;

namespace Skuo.IdentityServer.MongoDB
{
    [ConnectionStringName(SkuoIdentityServerDbProperties.ConnectionStringName)]
    public class SkuoIdentityServerMongoDbContext : AbpMongoDbContext, ISkuoIdentityServerMongoDbContext
    {
        public IMongoCollection<ApiResource> ApiResources => Collection<ApiResource>();

        public IMongoCollection<Client> Clients => Collection<Client>();

        public IMongoCollection<IdentityResource> IdentityResources => Collection<IdentityResource>();

        public IMongoCollection<PersistedGrant> PersistedGrants => Collection<PersistedGrant>();

        public IMongoCollection<DeviceFlowCodes> DeviceFlowCodes => Collection<DeviceFlowCodes>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureIdentityServer();
        }
    }
}
