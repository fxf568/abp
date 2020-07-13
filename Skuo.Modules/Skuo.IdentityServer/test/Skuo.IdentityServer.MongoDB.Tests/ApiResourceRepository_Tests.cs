using Xunit;

namespace Skuo.IdentityServer.Test
{
    [Collection(MongoTestCollection.Name)]
    public class ApiResourceRepository_Tests : ApiResourceRepository_Tests<SkuoIdentityServerMongoDbTestModule>
    {
    }
}
