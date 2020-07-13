using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Skuo.Identity.AspNetCore
{
    [DependsOn(
        typeof(SkuoIdentityDomainModule)
        )]
    public class SkuoIdentityAspNetCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IdentityBuilder>(builder =>
            {
                builder.AddDefaultTokenProviders();
                builder.AddSignInManager();
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //(TODO: Extract an extension method like IdentityBuilder.AddAbpSecurityStampValidator())
            context.Services.AddScoped<SkuoSecurityStampValidator>();
            context.Services.AddScoped(typeof(SecurityStampValidator<IdentityUser>), provider => provider.GetService(typeof(SkuoSecurityStampValidator)));
            context.Services.AddScoped(typeof(ISecurityStampValidator), provider => provider.GetService(typeof(SkuoSecurityStampValidator)));

            var options = context.Services.ExecutePreConfiguredActions(new SkuoIdentityAspNetCoreOptions());

            if (options.ConfigureAuthentication)
            {
                context.Services
                    .AddAuthentication(o =>
                    {
                        o.DefaultScheme = IdentityConstants.ApplicationScheme;
                        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                    })
                    .AddIdentityCookies();
            }
        }
    }
}
