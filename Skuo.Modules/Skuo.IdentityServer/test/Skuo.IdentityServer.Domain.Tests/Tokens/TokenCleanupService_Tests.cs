using Shouldly;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.Grants;
using Skuo.IdentityServer.Tests;
using Skuo.IdentityServer.Tokens;
using System.Threading.Tasks;
using Xunit;

namespace Skuo.IdentityServer.Test.Tokens
{
    public class TokenCleanupService_Tests : SkuoIdentityServerTestBase
    {
        private readonly IPersistentGrantRepository _persistentGrantRepository;
        private readonly IDeviceFlowCodesRepository _deviceFlowCodesRepository;
        private readonly TokenCleanupService _tokenCleanupService;

        public TokenCleanupService_Tests()
        {
            _persistentGrantRepository = GetRequiredService<IPersistentGrantRepository>();
            _deviceFlowCodesRepository = GetRequiredService<IDeviceFlowCodesRepository>();
            _tokenCleanupService = GetRequiredService<TokenCleanupService>();
        }

        [Fact]
        public async Task Should_Clear_Expired_Tokens()
        {
            var persistentGrantCount = await _persistentGrantRepository.GetCountAsync();
            var deviceFlowCodesCount = await _deviceFlowCodesRepository.GetCountAsync();

            await _tokenCleanupService.CleanAsync();

            (await _persistentGrantRepository.GetCountAsync())
                .ShouldBe(persistentGrantCount - 1);

            (await _deviceFlowCodesRepository.GetCountAsync())
                .ShouldBe(deviceFlowCodesCount - 1);
        }
    }
}
