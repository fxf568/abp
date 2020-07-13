using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skuo.Identity.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace  Skuo.Identity.Test
{
    public class LazyLoading_Tests : LazyLoading_Tests<SkuoIdentityEntityFrameworkCoreTestModule>
    {
        protected override void BeforeAddApplication(IServiceCollection services)
        {
            services.Configure<AbpDbContextOptions>(options =>
            {
                options.PreConfigure<IdentityDbContext>(context =>
                {
                    context.DbContextOptions.UseLazyLoadingProxies();
                });
            });
        }
    }
}
