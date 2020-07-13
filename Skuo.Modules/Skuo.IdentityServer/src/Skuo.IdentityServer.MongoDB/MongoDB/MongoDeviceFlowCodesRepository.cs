using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Skuo.IdentityServer.Devices;
using Volo.Abp.MongoDB;

namespace Skuo.IdentityServer.MongoDB
{
    public class MongoDeviceFlowCodesRepository :
        MongoDbRepository<ISkuoIdentityServerMongoDbContext, DeviceFlowCodes, long>, IDeviceFlowCodesRepository
    {
        public MongoDeviceFlowCodesRepository(
            IMongoDbContextProvider<ISkuoIdentityServerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public virtual async Task<DeviceFlowCodes> FindByUserCodeAsync(
            string userCode,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(d => d.UserCode == userCode, GetCancellationToken(cancellationToken))
                ;
        }

        public virtual async Task<DeviceFlowCodes> FindByDeviceCodeAsync(string deviceCode, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(d => d.DeviceCode == deviceCode, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<DeviceFlowCodes>> GetListByExpirationAsync(
            DateTime maxExpirationDate, 
            int maxResultCount,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .Where(x => x.Expiration != null && x.Expiration < maxExpirationDate)
                .OrderBy(x => x.ClientId)
                .Take(maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}