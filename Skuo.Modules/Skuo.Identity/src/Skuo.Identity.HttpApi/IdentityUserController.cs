using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Skuo.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("User")]
    [Route("api/identity/users")]
    public class IdentityUserController : AbpController, IIdentityUserAppService
    {
        protected IIdentityUserAppService UserAppService { get; }

        public IdentityUserController(IIdentityUserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<IdentityUserDto> GetAsync(long id)
        {
            return UserAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return UserAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return UserAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<IdentityUserDto> UpdateAsync(long id, IdentityUserUpdateDto input)
        {
            return UserAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return UserAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}/roles")]
        public virtual Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(long id)
        {
            return UserAppService.GetRolesAsync(id);
        }

        [HttpGet]
        [Route("assignable-roles")]
        public Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            return UserAppService.GetAssignableRolesAsync();
        }

        [HttpPut]
        [Route("{id}/roles")]
        public virtual Task UpdateRolesAsync(long id, IdentityUserUpdateRolesDto input)
        {
            return UserAppService.UpdateRolesAsync(id, input);
        }

        [HttpGet]
        [Route("by-username/{userName}")]
        public virtual Task<IdentityUserDto> FindByUsernameAsync(string username)
        {
            return UserAppService.FindByUsernameAsync(username);
        }

        [HttpGet]
        [Route("by-email/{email}")]
        public virtual Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return UserAppService.FindByEmailAsync(email);
        }
    }
}
