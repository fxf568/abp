using Skuo.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Skuo.Account
{
    [DependsOn(
        typeof(SkuoAccountApplicationContractsModule),
        typeof(SkuoIdentityApplicationModule),
        typeof(Snowflake.SkuoSnowflakeModule),
        typeof(AbpUiNavigationModule)
    )]
    public class SkuoAccountApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SkuoAccountApplicationModule>();
            });
        }
    }
}