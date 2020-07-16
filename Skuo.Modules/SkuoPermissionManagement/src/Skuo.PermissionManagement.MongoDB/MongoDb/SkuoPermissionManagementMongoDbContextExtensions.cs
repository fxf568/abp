using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Skuo.PermissionManagement.MongoDB
{
    public static class SkuoPermissionManagementMongoDbContextExtensions
    {
        public static void ConfigurePermissionManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new PermissionManagementMongoModelBuilderConfigurationOptions(
                SkuoPermissionManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<PermissionGrant>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "PermissionGrants";
            });
        }
    }
}