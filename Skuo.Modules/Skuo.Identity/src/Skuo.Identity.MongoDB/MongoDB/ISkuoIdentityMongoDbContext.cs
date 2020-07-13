using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Skuo.Identity.MongoDB
{
    [ConnectionStringName(SkuoIdentityDbProperties.ConnectionStringName)]
    public interface ISkuoIdentityMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<IdentityUser> Users { get; }

        IMongoCollection<IdentityRole> Roles { get; }

        IMongoCollection<IdentityClaimType> ClaimTypes { get; }

    }
}