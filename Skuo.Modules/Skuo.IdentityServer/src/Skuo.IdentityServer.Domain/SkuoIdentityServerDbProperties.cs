namespace Skuo.IdentityServer
{
    public static class SkuoIdentityServerDbProperties
    {
        public static string DbTablePrefix { get; set; } = "IdentityServer";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AbpIdentityServer";
    }
}
