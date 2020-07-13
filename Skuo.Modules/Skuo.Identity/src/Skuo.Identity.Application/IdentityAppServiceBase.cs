using Volo.Abp.Application.Services;
using Skuo.Identity.Localization;
using Volo.Abp.Users;

namespace Skuo.Identity
{
    public abstract class IdentityAppServiceBase : ApplicationService
    {
        public const string UserIdName = "Skuo.UserId";
        protected IdentityAppServiceBase()
        {
            ObjectMapperContext = typeof(SkuoIdentityApplicationModule);
            LocalizationResource = typeof(IdentityResource);
        }
        protected long? UserId
        {
            get
            {
                return base.CurrentUser.FindClaimValue<long>(UserIdName);
            }
        }
    }
}
