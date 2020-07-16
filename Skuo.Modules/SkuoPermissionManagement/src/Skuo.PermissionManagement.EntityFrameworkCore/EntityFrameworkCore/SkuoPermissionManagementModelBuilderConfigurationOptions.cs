using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Skuo.PermissionManagement.EntityFrameworkCore
{
    public class SkuoPermissionManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SkuoPermissionManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}