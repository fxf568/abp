using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Skuo.PermissionManagement
{
    [RemoteService(Name = PermissionManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("permissionManagement")]
    [Route("api/permission-management/permissions")]
    public class PermissionsController : AbpController, IPermissionAppService
    {
        protected IPermissionAppService PermissionAppService { get; }

        public PermissionsController(IPermissionAppService permissionAppService)
        {
            PermissionAppService = permissionAppService;
        }

        [HttpGet]
        public virtual Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey)
        {
            return PermissionAppService.GetAsync(providerName, providerKey);
        }

        [HttpPut]
        public virtual Task UpdateAsync(string providerName, string providerKey, UpdatePermissionsDto input)
        {
            return PermissionAppService.UpdateAsync(providerName, providerKey, input);
        }
    }
}
