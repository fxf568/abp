using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Skuo.Identity;
using Skuo.IdentityServer.ApiResources;
using Skuo.IdentityServer.Clients;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.Grants;
using Skuo.IdentityServer.IdentityResources;
using Volo.Abp.Timing;
using Skuo.Snowflake;

namespace Skuo.IdentityServer.Test
{
    public class SkuoIdentityServerTestDataBuilder : ITransientDependency
    {
        private readonly IIdGenerator _idGenerator;
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityResourceRepository _identityResourceRepository;
        private readonly IIdentityClaimTypeRepository _identityClaimTypeRepository;
        private readonly IPersistentGrantRepository _persistentGrantRepository;
        private readonly IDeviceFlowCodesRepository _deviceFlowCodesRepository;
        private readonly SkuoIdentityServerTestData _testData;
        private readonly IClock _clock;

        public IIdGenerator IdGenerator => _idGenerator;

        public SkuoIdentityServerTestDataBuilder(
            IIdGenerator idGenerator,
            IApiResourceRepository apiResourceRepository,
            IClientRepository clientRepository,
            IIdentityResourceRepository identityResourceRepository,
            IIdentityClaimTypeRepository identityClaimTypeRepository,
            SkuoIdentityServerTestData testData,
            IPersistentGrantRepository persistentGrantRepository,
            IDeviceFlowCodesRepository deviceFlowCodesRepository,
            IClock clock)
        {
            _testData = testData;
            _idGenerator = idGenerator;
            _apiResourceRepository = apiResourceRepository;
            _clientRepository = clientRepository;
            _identityResourceRepository = identityResourceRepository;
            _identityClaimTypeRepository = identityClaimTypeRepository;
            _persistentGrantRepository = persistentGrantRepository;
            _clock = clock;
            _deviceFlowCodesRepository = deviceFlowCodesRepository;
        }

        public async Task BuildAsync()
        {
            await AddDeviceFlowCodes();
            await AddPersistedGrants();
            await AddIdentityResources();
            await AddApiResources();
            await AddClients();
            await AddClaimTypes();
        }

        private async Task AddDeviceFlowCodes()
        {
            await _deviceFlowCodesRepository.InsertAsync(
                new DeviceFlowCodes(IdGenerator.NextId())
                {
                    ClientId = "c1",
                    DeviceCode = "DeviceCode1",
                    Expiration = _clock.Now.AddDays(1),
                    Data = "{\"Lifetime\":\"42\"}",
                    UserCode = "DeviceFlowCodesUserCode1",
                    SubjectId = "DeviceFlowCodesSubjectId1"
                }
            );

            await _deviceFlowCodesRepository.InsertAsync(
                new DeviceFlowCodes(IdGenerator.NextId())
                {
                    ClientId = "c1",
                    DeviceCode = "DeviceCode2",
                    Expiration = _clock.Now.AddDays(-1),
                    Data = "",
                    UserCode = "DeviceFlowCodesUserCode2",
                    SubjectId = "DeviceFlowCodesSubjectId2"
                }
            );

        }

        private async Task AddPersistedGrants()
        {
            await _persistentGrantRepository.InsertAsync(new PersistedGrant(IdGenerator.NextId())
            {
                Key = "PersistedGrantKey1",
                SubjectId = "PersistedGrantSubjectId1",
                ClientId = "PersistedGrantClientId1",
                Type = "PersistedGrantType1",
                Data = ""
            });

            await _persistentGrantRepository.InsertAsync(new PersistedGrant(IdGenerator.NextId())
            {
                Key = "PersistedGrantKey2",
                SubjectId = "PersistedGrantSubjectId2",
                ClientId = "c1",
                Type = "c1type",
                Data = ""
            });

            await _persistentGrantRepository.InsertAsync(new PersistedGrant(IdGenerator.NextId())
            {
                Key = "PersistedGrantKey3",
                SubjectId = "PersistedGrantSubjectId3",
                ClientId = "c1",
                Type = "c1type",
                Data = "",
                Expiration = _clock.Now.AddDays(1),
            });

            await _persistentGrantRepository.InsertAsync(new PersistedGrant(IdGenerator.NextId())
            {
                Key = "PersistedGrantKey_Expired1",
                SubjectId = "PersistedGrantSubjectId_Expired1",
                ClientId = "c1",
                Type = "c1type",
                Data = "",
                Expiration = _clock.Now.AddDays(-1)
            });
        }

        private async Task AddIdentityResources()
        {
            var identityResource = new IdentityResource(_testData.IdentityResource1Id, "NewIdentityResource1")
            {
                Description = nameof(Client.Description),
                DisplayName = nameof(IdentityResource.DisplayName)
            };

            identityResource.AddUserClaim(nameof(ApiResourceClaim.Type));

            await _identityResourceRepository.InsertAsync(identityResource);
            await _identityResourceRepository.InsertAsync(new IdentityResource(IdGenerator.NextId(), "NewIdentityResource2"));
            await _identityResourceRepository.InsertAsync(new IdentityResource(IdGenerator.NextId(), "NewIdentityResource3"));
        }

        private async Task AddApiResources()
        {
            var apiResource = new ApiResource(_testData.ApiResource1Id, "NewApiResource1");
            apiResource.Description = nameof(apiResource.Description);
            apiResource.DisplayName = nameof(apiResource.DisplayName);

            apiResource.AddScope(nameof(ApiScope.Name));
            apiResource.AddUserClaim(nameof(ApiResourceClaim.Type));
            apiResource.AddSecret(nameof(ApiSecret.Value));

            await _apiResourceRepository.InsertAsync(apiResource);
            await _apiResourceRepository.InsertAsync(new ApiResource(IdGenerator.NextId(), "NewApiResource2"));
            await _apiResourceRepository.InsertAsync(new ApiResource(IdGenerator.NextId(), "NewApiResource3"));
        }

        private async Task AddClients()
        {
            var client = new Client(_testData.Client1Id, "ClientId1")
            {
                Description = nameof(Client.Description),
                ClientName = nameof(Client.ClientName),
                ClientUri = nameof(Client.ClientUri),
                LogoUri = nameof(Client.LogoUri),
                ProtocolType = nameof(Client.ProtocolType),
                FrontChannelLogoutUri = nameof(Client.FrontChannelLogoutUri)
            };

            client.AddCorsOrigin("https://client1-origin.com");
            client.AddClaim(nameof(ClientClaim.Value), nameof(ClientClaim.Type));
            client.AddGrantType(nameof(ClientGrantType.GrantType));
            client.AddIdentityProviderRestriction(nameof(ClientIdPRestriction.Provider));
            client.AddPostLogoutRedirectUri(nameof(ClientPostLogoutRedirectUri.PostLogoutRedirectUri));
            client.AddProperty(nameof(ClientProperty.Key), nameof(ClientProperty.Value));
            client.AddRedirectUri(nameof(ClientRedirectUri.RedirectUri));
            client.AddScope(nameof(ClientScope.Scope));
            client.AddSecret(nameof(ClientSecret.Value));

            await _clientRepository.InsertAsync(client);

            await _clientRepository.InsertAsync(new Client(IdGenerator.NextId(), "ClientId2"));
            await _clientRepository.InsertAsync(new Client(IdGenerator.NextId(), "ClientId3"));
        }

        private async Task AddClaimTypes()
        {
            var ageClaim = new IdentityClaimType(IdGenerator.NextId(), "Age", false, false, null, null, null,
                IdentityClaimValueType.Int);
            await _identityClaimTypeRepository.InsertAsync(ageClaim);
        }
    }
}
