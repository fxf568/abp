using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Skuo.Users
{
    public interface IUserRepository<TUser> : IBasicRepository<TUser,long>
        where TUser : class, IUser, IAggregateRoot<long>
    {
        Task<TUser> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);

        Task<List<TUser>> GetListAsync(IEnumerable<long> ids, CancellationToken cancellationToken = default);

        Task<List<TUser>> SearchAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default);
    }
  
}