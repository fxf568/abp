using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Skuo.PermissionManagement.MongoDB
{
    [ConnectionStringName(SkuoPermissionManagementDbProperties.ConnectionStringName)]
    public interface IPermissionManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<PermissionGrant> PermissionGrants { get; }
    }
}