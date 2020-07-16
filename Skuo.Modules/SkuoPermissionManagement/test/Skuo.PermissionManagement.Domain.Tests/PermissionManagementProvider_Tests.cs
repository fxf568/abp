using System;
using System.Threading.Tasks;
using Shouldly;
using Skuo.Snowflake;
using Volo.Abp.Authorization.Permissions;
using Xunit;

namespace Skuo.PermissionManagement
{
    public class PermissionManagementProvider_Tests : PermissionTestBase
    {
        private readonly IPermissionManagementProvider _permissionManagementProvider;
        private readonly IPermissionGrantRepository _permissionGrantRepository;
        private readonly IIdGenerator _idGenerator;

        public PermissionManagementProvider_Tests()
        {
            _permissionManagementProvider = GetRequiredService<TestPermissionManagementProvider>();
            _permissionGrantRepository = GetRequiredService<IPermissionGrantRepository>();
            _idGenerator= GetRequiredService<IIdGenerator>();
        }


        [Fact]
        public async Task CheckAsync()
        {
            await _permissionGrantRepository.InsertAsync(
                new PermissionGrant(
                   _idGenerator.NextId(),
                    "MyPermission1",
                    "Test",
                    "Test"
                )
            );

            var permissionValueProviderGrantInfo = await _permissionManagementProvider.CheckAsync("MyPermission1",
                "Test",
                "Test");

            permissionValueProviderGrantInfo.IsGranted.ShouldBeTrue();
            permissionValueProviderGrantInfo.ProviderKey.ShouldBe("Test");
        }

        [Fact]
        public async Task Check_Should_Return_NonGranted_When_ProviderName_NotEquals_Name()
        {
            var permissionValueProviderGrantInfo = await _permissionManagementProvider.CheckAsync("MyPermission1",
                "TestNotExist",
                "Test");

            permissionValueProviderGrantInfo.IsGranted.ShouldBeFalse();
            permissionValueProviderGrantInfo.ProviderKey.ShouldBeNull();
        }


        [Fact]
        public async Task SetAsync()
        {
            await _permissionGrantRepository.InsertAsync(
                new PermissionGrant(
                    _idGenerator.NextId(),
                    "MyPermission1",
                    "Test",
                    "Test"
                )
            );
            (await _permissionGrantRepository.FindAsync("MyPermission1",
                "Test",
                "Test")).ShouldNotBeNull();

            await _permissionManagementProvider.SetAsync("MyPermission1",
                "Test",
                false);

            (await _permissionGrantRepository.FindAsync("MyPermission1",
                "Test",
                "Test")).ShouldBeNull();
        }

    }
}
