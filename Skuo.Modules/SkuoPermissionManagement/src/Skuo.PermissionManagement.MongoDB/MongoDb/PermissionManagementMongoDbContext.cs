using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Skuo.PermissionManagement.MongoDB
{
    [ConnectionStringName(SkuoPermissionManagementDbProperties.ConnectionStringName)]
    public class PermissionManagementMongoDbContext : AbpMongoDbContext, IPermissionManagementMongoDbContext
    {
        public IMongoCollection<PermissionGrant> PermissionGrants => Collection<PermissionGrant>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigurePermissionManagement();
        }
    }
}