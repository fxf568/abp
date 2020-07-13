using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Skuo.IdentityServer.MongoDB
{
    public class IdentityServerMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public IdentityServerMongoModelBuilderConfigurationOptions([NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
