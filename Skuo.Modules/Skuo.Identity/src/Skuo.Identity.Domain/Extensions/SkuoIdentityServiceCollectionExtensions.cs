using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skuo.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SkuoIdentityServiceCollectionExtensions
    {
        public static IdentityBuilder AddAbpIdentity(this IServiceCollection services)
        {
            return services.AddAbpIdentity(setupAction: null);
        }

        public static IdentityBuilder AddAbpIdentity(this IServiceCollection services, Action<IdentityOptions> setupAction)
        {
            //SkuoRoleManager
            services.TryAddScoped<IdentityRoleManager>();
            services.TryAddScoped(typeof(RoleManager<IdentityRole>), provider => provider.GetService(typeof(IdentityRoleManager)));

            //SkuoUserManager
            services.TryAddScoped<IdentityUserManager>();
            services.TryAddScoped(typeof(UserManager<IdentityUser>), provider => provider.GetService(typeof(IdentityUserManager)));

            //SkuoUserStore
            services.TryAddScoped<IdentityUserStore>();
            services.TryAddScoped(typeof(IUserStore<IdentityUser>), provider => provider.GetService(typeof(IdentityUserStore)));

            //SkuoRoleStore
            services.TryAddScoped<IdentityRoleStore>();
            services.TryAddScoped(typeof(IRoleStore<IdentityRole>), provider => provider.GetService(typeof(IdentityRoleStore)));
            
            return services
                .AddIdentityCore<IdentityUser>(setupAction)
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<SkuoUserClaimsPrincipalFactory>();
        }
    }
}
