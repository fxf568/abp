using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Skuo.IdentityServer.IdentityResources;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Skuo.IdentityServer.Test
{
    public abstract class IdentityResourceRepository_Tests<TStartupModule> : SkuoIdentityServerTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        protected IIdentityResourceRepository identityResourceRepository;

        public IdentityResourceRepository_Tests()
        {
            identityResourceRepository = ServiceProvider.GetRequiredService<IIdentityResourceRepository>();
        }

        [Fact]
        public async Task GetListByScopesAsync()
        {
            (await identityResourceRepository.GetListByScopesAsync(new[] { "", "NewIdentityResource2" })).Count.ShouldBe(1);
        }
    }
}
