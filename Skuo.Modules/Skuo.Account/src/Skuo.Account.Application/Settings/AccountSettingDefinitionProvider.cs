using Skuo.Account.Settings;
using Skuo.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Skuo.Account.Settings
{
    public class AccountSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    AccountSettingNames.IsSelfRegistrationEnabled, 
                    "true", 
                    L("DisplayName:Skuo.Account.IsSelfRegistrationEnabled"), 
                    L("Description:Skuo.Account.IsSelfRegistrationEnabled"), isVisibleToClients : true)
            );

            context.Add(
                new SettingDefinition(
                    AccountSettingNames.EnableLocalLogin, 
                    "true", 
                    L("DisplayName:Skuo.Account.EnableLocalLogin"), 
                    L("Description:Skuo.Account.EnableLocalLogin"), isVisibleToClients : true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AccountResource>(name);
        }
    }
}