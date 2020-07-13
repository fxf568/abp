using Skuo.Identity.Localization;
using Skuo.Identity.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Skuo.Identity
{
    public class SkuoIdentitySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    IdentitySettingNames.Password.RequiredLength,
                    6.ToString(),
                    L("DisplayName:Skuo.Identity.Password.RequiredLength"),
                    L("Description:Skuo.Identity.Password.RequiredLength"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequiredUniqueChars,
                    1.ToString(),
                    L("DisplayName:Skuo.Identity.Password.RequiredUniqueChars"),
                    L("Description:Skuo.Identity.Password.RequiredUniqueChars"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireNonAlphanumeric,
                    true.ToString(),
                    L("DisplayName:Skuo.Identity.Password.RequireNonAlphanumeric"),
                    L("Description:Skuo.Identity.Password.RequireNonAlphanumeric"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireLowercase,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.Password.RequireLowercase"),
                    L("Description:Skuo.Identity.Password.RequireLowercase"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireUppercase,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.Password.RequireUppercase"),
                    L("Description:Skuo.Identity.Password.RequireUppercase"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireDigit,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.Password.RequireDigit"),
                    L("Description:Skuo.Identity.Password.RequireDigit"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Lockout.AllowedForNewUsers,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.Lockout.AllowedForNewUsers"),
                    L("Description:Skuo.Identity.Lockout.AllowedForNewUsers"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Lockout.LockoutDuration,
                    (5 * 60).ToString(), 
                    L("DisplayName:Skuo.Identity.Lockout.LockoutDuration"),
                    L("Description:Skuo.Identity.Lockout.LockoutDuration"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Lockout.MaxFailedAccessAttempts,
                    5.ToString(), 
                    L("DisplayName:Skuo.Identity.Lockout.MaxFailedAccessAttempts"),
                    L("Description:Skuo.Identity.Lockout.MaxFailedAccessAttempts"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.SignIn.RequireConfirmedEmail,
                    false.ToString(), 
                    L("DisplayName:Skuo.Identity.SignIn.RequireConfirmedEmail"),
                    L("Description:Skuo.Identity.SignIn.RequireConfirmedEmail"),
                    true),
                new SettingDefinition(
                    IdentitySettingNames.SignIn.EnablePhoneNumberConfirmation, 
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.SignIn.EnablePhoneNumberConfirmation"), 
                    L("Description:Skuo.Identity.SignIn.EnablePhoneNumberConfirmation"), 
                    true),
                new SettingDefinition(
                    IdentitySettingNames.SignIn.RequireConfirmedPhoneNumber, 
                    false.ToString(), 
                    L("DisplayName:Skuo.Identity.SignIn.RequireConfirmedPhoneNumber"), 
                    L("Description:Skuo.Identity.SignIn.RequireConfirmedPhoneNumber"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.User.IsUserNameUpdateEnabled,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.User.IsUserNameUpdateEnabled"),
                    L("Description:Skuo.Identity.User.IsUserNameUpdateEnabled"),
                    true),

                new SettingDefinition(
                    IdentitySettingNames.User.IsEmailUpdateEnabled,
                    true.ToString(), 
                    L("DisplayName:Skuo.Identity.User.IsEmailUpdateEnabled"),
                    L("Description:Skuo.Identity.User.IsEmailUpdateEnabled"),
                    true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IdentityResource>(name);
        }
    }
}
