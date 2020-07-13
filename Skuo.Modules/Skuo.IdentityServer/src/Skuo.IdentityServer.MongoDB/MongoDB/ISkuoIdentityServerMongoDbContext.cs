using MongoDB.Driver;
using Volo.Abp.Data;
using Skuo.IdentityServer.Clients;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.Grants;
using Skuo.IdentityServer.IdentityResources;
using Volo.Abp.MongoDB;
using ApiResource = Skuo.IdentityServer.ApiResources.ApiResource;

namespace Skuo.IdentityServer.MongoDB
{
    [ConnectionStringName(SkuoIdentityServerDbProperties.ConnectionStringName)]
    public interface ISkuoIdentityServerMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<ApiResource> ApiResources { get; }

        IMongoCollection<Client> Clients { get; }

        IMongoCollection<IdentityResource> IdentityResources { get; }

        IMongoCollection<PersistedGrant> PersistedGrants { get; }

        IMongoCollection<DeviceFlowCodes> DeviceFlowCodes { get; }
    }
}
