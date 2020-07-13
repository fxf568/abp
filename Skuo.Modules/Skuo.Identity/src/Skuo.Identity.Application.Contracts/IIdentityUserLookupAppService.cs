using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Skuo.Users;

namespace Skuo.Identity
{
    public interface IIdentityUserLookupAppService : IApplicationService
    {
        Task<UserData> FindByIdAsync(long id);

        Task<UserData> FindByUserNameAsync(string userName);

        Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input);
        
        Task<long> GetCountAsync(UserLookupCountInputDto input);
    }
}
