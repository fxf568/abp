using Volo.Abp.Data;

namespace Skuo.Identity
{
    public static class SkuoIdentityDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "SkuoIdentity";
    }
}
