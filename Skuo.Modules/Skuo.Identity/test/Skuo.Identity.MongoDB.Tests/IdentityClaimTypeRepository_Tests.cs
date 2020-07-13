using Xunit;

namespace Skuo.Identity.Test
{
    [Collection(MongoTestCollection.Name)]
    public class IdentityClaimTypeRepository_Tests : IdentityClaimTypeRepository_Tests<SkuoIdentityMongoDbTestModule>
    {

    }
}
