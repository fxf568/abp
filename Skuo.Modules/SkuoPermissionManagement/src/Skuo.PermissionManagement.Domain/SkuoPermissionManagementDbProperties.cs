using Volo.Abp.Data;

namespace Skuo.PermissionManagement
{
    public static class SkuoPermissionManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpPermissionManagement";
    }
}
