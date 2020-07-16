using Xunit;

namespace Skuo.PermissionManagement.MongoDB
{
    [Collection(MongoTestCollection.Name)]
    public class PermissionGrantRepository_Tests : PermissionGrantRepository_Tests<SkuoPermissionManagementMongoDbTestModule>
    {

    }
}
