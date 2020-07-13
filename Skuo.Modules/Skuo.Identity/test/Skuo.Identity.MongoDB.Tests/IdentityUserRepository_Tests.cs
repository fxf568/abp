using Xunit;

namespace Skuo.Identity.Test
{
    [Collection(MongoTestCollection.Name)]
    public class IdentityUserRepository_Tests : IdentityUserRepository_Tests<SkuoIdentityMongoDbTestModule>
    {

    }
}
