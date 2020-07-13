using Microsoft.Extensions.Localization;
using Shouldly;
using Skuo.Identity.Test;
using Skuo.Identity.Localization;
using Xunit;

namespace Volo.Abp.TenantManagement
{
    public class Localization_Tests : SkuoIdentityDomainTestBase
    {
        private readonly IStringLocalizer<IdentityResource> _stringLocalizer;

        public Localization_Tests()
        {
            _stringLocalizer = GetRequiredService<IStringLocalizer<IdentityResource>>();
        }

        [Fact]
        public void Test()
        {
            _stringLocalizer["PersonalSettingsSavedMessage"].Value
            .ShouldBe("Your personal settings has been saved successfully.");
        }
    }
}