using Xunit;

namespace Skuo.Identity.Test
{
    [Collection(MongoTestCollection.Name)]
    public class IdentityRoleRepository_Tests : IdentityRoleRepository_Tests<SkuoIdentityMongoDbTestModule>
    {

    }
}
