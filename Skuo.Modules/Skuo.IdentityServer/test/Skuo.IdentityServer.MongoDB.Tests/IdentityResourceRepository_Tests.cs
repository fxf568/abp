using Xunit;

namespace Skuo.IdentityServer.Test
{
    [Collection(MongoTestCollection.Name)]
    public class IdentityResourceRepository_Tests : IdentityResourceRepository_Tests<SkuoIdentityServerMongoDbTestModule>
    {
    }
}
