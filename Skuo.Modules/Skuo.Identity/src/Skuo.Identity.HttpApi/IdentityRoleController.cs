﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Skuo.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("Role")]
    [Route("api/identity/roles")]
    public class IdentityRoleController : AbpController, IIdentityRoleAppService
    {
        protected IIdentityRoleAppService RoleAppService { get; }

        public IdentityRoleController(IIdentityRoleAppService roleAppService)
        {
            RoleAppService = roleAppService;
        }

        [HttpGet]
        [Route("all")]
        public virtual Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            return RoleAppService.GetAllListAsync();
        }

        [HttpGet]
        public virtual Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return RoleAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<IdentityRoleDto> GetAsync(long id)
        {
            return RoleAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            return RoleAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<IdentityRoleDto> UpdateAsync(long id, IdentityRoleUpdateDto input)
        {
            return RoleAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return RoleAppService.DeleteAsync(id);
        }
    }
}
