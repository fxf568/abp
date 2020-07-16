using Skuo.Snowflake;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Skuo.PermissionManagement
{
    public class PermissionDataSeeder : IPermissionDataSeeder, ITransientDependency
    {
        protected IPermissionGrantRepository PermissionGrantRepository { get; }
        protected IIdGenerator IdGenerator { get; }

        public PermissionDataSeeder(
            IPermissionGrantRepository permissionGrantRepository,
            IIdGenerator idGenerator)
        {
            PermissionGrantRepository = permissionGrantRepository;
            IdGenerator = idGenerator;
        }

        public virtual async Task SeedAsync(
            string providerName, 
            string providerKey,
            IEnumerable<string> grantedPermissions,
            Guid? tenantId = null)
        {
            foreach (var permissionName in grantedPermissions)
            {
                if (await PermissionGrantRepository.FindAsync(permissionName, providerName, providerKey) != null)
                {
                    continue;
                }

                await PermissionGrantRepository.InsertAsync(
                    new PermissionGrant(
                        IdGenerator.NextId(),
                        permissionName,
                        providerName,
                        providerKey,
                        tenantId
                    )
                );
            }
        }
    }
}