using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Skuo.Snowflake;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;

namespace Skuo.Identity
{
    [Authorize(IdentityPermissions.Roles.Default)]
    public class IdentityRoleAppService : IdentityAppServiceBase, IIdentityRoleAppService
    {
        protected IdentityRoleManager RoleManager { get; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IIdGenerator IdGenerator { get; }
        public IdentityRoleAppService(
            IdentityRoleManager roleManager,
            IIdentityRoleRepository roleRepository,
            IIdGenerator idGenerator)
        {
            RoleManager = roleManager;
            RoleRepository = roleRepository;
            IdGenerator = idGenerator;
        }

        public virtual async Task<IdentityRoleDto> GetAsync(long id)
        {
            return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(
                await RoleManager.GetByIdAsync(id)
            );
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            var list = await RoleRepository.GetListAsync();
            return new ListResultDto<IdentityRoleDto>(
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list)
            );
        }

        public virtual async Task<PagedResultDto<IdentityRoleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = await RoleRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount);
            var totalCount = await RoleRepository.GetCountAsync();

            return new PagedResultDto<IdentityRoleDto>(
                totalCount,
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list)
                );
        }

        [Authorize(IdentityPermissions.Roles.Create)]
        public virtual async Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            var role = new IdentityRole(
                IdGenerator.NextId(),
                input.Name,
                CurrentTenant.Id
            )
            {
                IsDefault = input.IsDefault,
                IsPublic = input.IsPublic
            };

            input.MapExtraPropertiesTo(role);

            (await RoleManager.CreateAsync(role)).CheckErrors();
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
        }

        [Authorize(IdentityPermissions.Roles.Update)]
        public virtual async Task<IdentityRoleDto> UpdateAsync(long id, IdentityRoleUpdateDto input)
        {
            var role = await RoleManager.GetByIdAsync(id);
            role.ConcurrencyStamp = input.ConcurrencyStamp;

            (await RoleManager.SetRoleNameAsync(role, input.Name)).CheckErrors();

            role.IsDefault = input.IsDefault;
            role.IsPublic = input.IsPublic;

            input.MapExtraPropertiesTo(role);

            (await RoleManager.UpdateAsync(role)).CheckErrors();
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
        }

        [Authorize(IdentityPermissions.Roles.Delete)]
        public virtual async Task DeleteAsync(long id)
        {
            var role = await RoleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return;
            }

            (await RoleManager.DeleteAsync(role)).CheckErrors();
        }
    }
}
