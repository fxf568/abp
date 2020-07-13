using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Skuo.Identity.MongoDB
{
    public static class SkuoIdentityMongoDbContextExtensions
    {
        public static void ConfigureIdentity(
            this IMongoModelBuilder builder,
            Action<IdentityMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new IdentityMongoModelBuilderConfigurationOptions(
                SkuoIdentityDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<IdentityUser>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Users";
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Roles";
            });

            builder.Entity<IdentityClaimType>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ClaimTypes";
            });
        }
    }
}