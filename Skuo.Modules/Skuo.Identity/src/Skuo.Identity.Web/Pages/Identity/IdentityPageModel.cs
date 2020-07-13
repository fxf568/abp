using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Skuo.Identity.Web.Pages.Identity
{
    public abstract class IdentityPageModel : AbpPageModel
    {
        protected IdentityPageModel()
        {
            ObjectMapperContext = typeof(SkuoIdentityWebModule);
        }
    }
}
