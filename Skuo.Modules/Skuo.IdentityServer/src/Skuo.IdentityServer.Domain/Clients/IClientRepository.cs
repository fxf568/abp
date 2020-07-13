using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Skuo.IdentityServer.Clients
{
    public interface IClientRepository : IBasicRepository<Client, long>
    {
        Task<Client> FindByCliendIdAsync(
            [NotNull] string clientId,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<List<Client>> GetListAsync(
            string sorting,
            int skipCount,
            int maxResultCount,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<string>> GetAllDistinctAllowedCorsOriginsAsync(CancellationToken cancellationToken = default);

        Task<bool> CheckClientIdExistAsync(
            string clientId,
            long? expectedId = null,
            CancellationToken cancellationToken = default
        );
    }
}