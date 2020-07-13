﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Skuo.IdentityServer.Grants;
using Volo.Abp.MongoDB;

namespace Skuo.IdentityServer.MongoDB
{
    public class MongoPersistentGrantRepository : MongoDbRepository<ISkuoIdentityServerMongoDbContext, PersistedGrant, long>, IPersistentGrantRepository
    {
        public MongoPersistentGrantRepository(IMongoDbContextProvider<ISkuoIdentityServerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<PersistedGrant> FindByKeyAsync(string key, CancellationToken cancellationToken = default)
        {

            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.Key == key, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<PersistedGrant>> GetListBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .Where(x => x.SubjectId == subjectId)
                .ToListAsync(GetCancellationToken(cancellationToken))
                ;
        }

        public virtual async Task<List<PersistedGrant>> GetListByExpirationAsync(DateTime maxExpirationDate, int maxResultCount,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .Where(x => x.Expiration != null && x.Expiration < maxExpirationDate)
                .OrderBy(x => x.ClientId)
                .Take(maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task DeleteAsync(string subjectId, string clientId, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(
                x => x.SubjectId == subjectId && x.ClientId == clientId,
                cancellationToken: GetCancellationToken(cancellationToken)
            );
        }

        public virtual async Task DeleteAsync(string subjectId, string clientId, string type, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(
                x => x.SubjectId == subjectId && x.ClientId == clientId && x.Type == type,
                cancellationToken: GetCancellationToken(cancellationToken)
            );
        }
    }
}
