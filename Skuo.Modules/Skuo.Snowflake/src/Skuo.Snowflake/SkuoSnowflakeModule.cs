using Skuo.Snowflake.Settings;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Skuo.Snowflake
{
    [DependsOn(typeof(AbpSettingsModule))]
    public class SkuoSnowflakeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<SnowflakeSettingProvider>();
            });
        }
    }
}
