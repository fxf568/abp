﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace Skuo.PermissionManagement
{
    public interface IPermissionAppService : IApplicationService
    {
        Task<GetPermissionListResultDto> GetAsync([NotNull] string providerName, [NotNull] string providerKey);

        Task UpdateAsync([NotNull] string providerName, [NotNull] string providerKey, UpdatePermissionsDto input);
    }
}