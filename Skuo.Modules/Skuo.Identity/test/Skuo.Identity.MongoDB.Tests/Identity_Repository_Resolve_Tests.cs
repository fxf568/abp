﻿using Xunit;

namespace Skuo.Identity.Test
{
    [Collection(MongoTestCollection.Name)]
    public class Identity_Repository_Resolve_Tests : Identity_Repository_Resolve_Tests<SkuoIdentityMongoDbTestModule>
    {
    }
}
