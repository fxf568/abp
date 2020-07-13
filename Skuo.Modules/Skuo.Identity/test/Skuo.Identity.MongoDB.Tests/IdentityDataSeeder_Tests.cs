using Xunit;

namespace Skuo.Identity.Test
{
    [Collection(MongoTestCollection.Name)]
    public class IdentityDataSeeder_Tests : IdentityDataSeeder_Tests<SkuoIdentityMongoDbTestModule>
    {

    }
}
