using Xunit;

namespace Skuo.IdentityServer.Test
{
    [Collection(MongoTestCollection.Name)]
    public class PersistentGrantRepository_Tests : PersistentGrantRepository_Tests<SkuoIdentityServerMongoDbTestModule>
    {

    }
}
