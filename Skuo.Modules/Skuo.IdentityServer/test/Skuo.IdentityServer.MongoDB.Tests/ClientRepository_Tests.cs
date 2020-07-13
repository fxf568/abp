using Xunit;

namespace Skuo.IdentityServer.Test
{
    [Collection(MongoTestCollection.Name)]
    public class ClientRepository_Tests : ClientRepository_Tests<SkuoIdentityServerMongoDbTestModule>
    {

    }
}
