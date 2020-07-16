using Skuo.Snowflake;
using System;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Skuo.PermissionManagement
{
    public class PermissionTestDataBuilder : ITransientDependency
    {
        public static long User1Id { get; private set; }
        public static long User2Id { get; private set; }

        private readonly IPermissionGrantRepository _permissionGrantRepository;
        private readonly IIdGenerator _idGenerator;

        public PermissionTestDataBuilder(IIdGenerator idGenerator, IPermissionGrantRepository permissionGrantRepository)
        {
            _idGenerator = idGenerator;
            _permissionGrantRepository = permissionGrantRepository;
            User1Id = _idGenerator.NextId();
            User2Id = _idGenerator.NextId();
        }

        public async Task BuildAsync()
        {
            await _permissionGrantRepository.InsertAsync(
                new PermissionGrant(
                    _idGenerator.NextId(),
                    "MyPermission1",
                    UserPermissionValueProvider.ProviderName,
                    User1Id.ToString()
                )
            );

            await _permissionGrantRepository.InsertAsync(
                new PermissionGrant(
                    _idGenerator.NextId(),
                    "MyDisabledPermission1",
                    UserPermissionValueProvider.ProviderName,
                    User1Id.ToString()
                )
            );

            await _permissionGrantRepository.InsertAsync(
                new PermissionGrant(
                    _idGenerator.NextId(),
                    "MyPermission3",
                    UserPermissionValueProvider.ProviderName,
                    User1Id.ToString()
                )
            );
        }
    }
}