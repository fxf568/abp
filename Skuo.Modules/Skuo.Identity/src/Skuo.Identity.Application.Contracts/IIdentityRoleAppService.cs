using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Skuo.Identity
{
    public interface IIdentityRoleAppService : IApplicationService
    {
        Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();
        
        Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);

        Task<IdentityRoleDto> GetAsync(long id);

        Task<IdentityRoleDto> UpdateAsync(long id, IdentityRoleUpdateDto input);

        Task DeleteAsync(long id);
    }
}
