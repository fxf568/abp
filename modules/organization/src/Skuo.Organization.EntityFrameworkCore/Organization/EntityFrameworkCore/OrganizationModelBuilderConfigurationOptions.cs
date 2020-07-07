using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Skuo.Organization.EntityFrameworkCore
{
    public class OrganizationModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public OrganizationModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = OrganizationConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = OrganizationConsts.DefaultDbSchema)
            : base(tablePrefix, schema)
        {

        }
    }
}