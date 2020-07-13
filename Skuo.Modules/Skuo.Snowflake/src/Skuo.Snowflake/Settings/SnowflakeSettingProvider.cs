using Volo.Abp.Settings;

namespace Skuo.Snowflake.Settings
{
    public class SnowflakeSettingProvider : SettingDefinitionProvider
    {
        
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add
            (
                new SettingDefinition(SnowflakeSettingNames.MachineIdSettingName, "1"),
                new SettingDefinition(SnowflakeSettingNames.DatacenterIdSettingName, "1"),
                new SettingDefinition(SnowflakeSettingNames.SequenceSettingName, "0")
            );
        }
    }
}
