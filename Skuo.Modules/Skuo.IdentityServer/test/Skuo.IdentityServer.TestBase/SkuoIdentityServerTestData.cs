using System;
using Volo.Abp.DependencyInjection;

namespace Skuo.IdentityServer.Test
{
    public class SkuoIdentityServerTestData : ISingletonDependency
    {
        public long Client1Id { get; } = GetId();

        public long ApiResource1Id { get; } = GetId();

        public long IdentityResource1Id { get; } = GetId();
        private static long GetId()
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next();

        }

    }
}
