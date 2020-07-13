using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Skuo.Identity
{
    public interface IIdentityUserRepository : IBasicRepository<IdentityUser, long>
    {
        Task<IdentityUser> FindByNormalizedUserNameAsync(
            [NotNull] string normalizedUserName,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<List<string>> GetRoleNamesAsync(
            long id,
            CancellationToken cancellationToken = default
        );


        Task<IdentityUser> FindByLoginAsync(
            [NotNull] string loginProvider,
            [NotNull] string providerKey,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<IdentityUser> FindByNormalizedEmailAsync(
            [NotNull] string normalizedEmail,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListByClaimAsync(
            Claim claim,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListByNormalizedRoleNameAsync(
            string normalizedRoleName,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityRole>> GetRolesAsync(
            long id,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}
