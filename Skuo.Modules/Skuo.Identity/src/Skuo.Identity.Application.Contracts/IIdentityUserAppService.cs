using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Skuo.Identity
{
    public interface IIdentityUserAppService : ICrudAppService<IdentityUserDto, long, GetIdentityUsersInput, IdentityUserCreateDto, IdentityUserUpdateDto>
    {
        Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(long id);

        Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync();

        Task UpdateRolesAsync(long id, IdentityUserUpdateRolesDto input);

        Task<IdentityUserDto> FindByUsernameAsync(string username);

        Task<IdentityUserDto> FindByEmailAsync(string email);
    }
}
