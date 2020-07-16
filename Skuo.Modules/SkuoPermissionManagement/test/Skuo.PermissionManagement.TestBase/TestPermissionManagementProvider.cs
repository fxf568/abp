using Skuo.Snowflake;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Skuo.PermissionManagement
{
    public class TestPermissionManagementProvider : PermissionManagementProvider
    {
        public override string Name => "Test";

        public TestPermissionManagementProvider(
            IPermissionGrantRepository permissionGrantRepository,
            IIdGenerator idGenerator,
            ICurrentTenant currentTenant)
            : base(
                permissionGrantRepository,
                idGenerator,
                currentTenant)
        {

        }
    }
}
