using Microsoft.AspNetCore.Identity;
using Shouldly;
using Skuo.Identity.Localization;
using System.Globalization;
using Volo.Abp.Localization;
using Xunit;

namespace Skuo.Identity.Test
{
    public class SkuoIdentityResultException_Tests : SkuoIdentityDomainTestBase
    {
        [Fact]
        public void Should_Localize_Messages()
        {
            var exception = new SkuoIdentityResultException(
                IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "PasswordTooShort",
                        Description = "Passwords must be at least 6 characters."
                    },
                    new IdentityError
                    {
                        Code = "PasswordRequiresNonAlphanumeric",
                        Description = "Passwords must have at least one non alphanumeric character."
                    }
                )
            );
            using (CultureHelper.Use("zh-Hans"))
            {
                
                var localizationContext = new LocalizationContext(ServiceProvider);
                var localizeMessage = exception.LocalizeMessage(localizationContext);
                
                localizeMessage.ShouldContain("密码至少为6个字符.");
                localizeMessage.ShouldContain("密码至少包含一位非字母数字字符.");
            }
        }
    }
}
