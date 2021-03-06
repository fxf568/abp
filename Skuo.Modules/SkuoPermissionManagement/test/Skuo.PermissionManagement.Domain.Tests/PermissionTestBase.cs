﻿using System;
using Skuo.PermissionManagement.EntityFrameworkCore;

namespace Skuo.PermissionManagement
{
    public abstract class PermissionTestBase : PermissionManagementTestBase<SkuoPermissionManagementTestModule>
    {
        protected virtual void UsingDbContext(Action<IPermissionManagementDbContext> action)
        {
            using (var dbContext = GetRequiredService<IPermissionManagementDbContext>())
            {
                action.Invoke(dbContext);
            }
        }

        protected virtual T UsingDbContext<T>(Func<IPermissionManagementDbContext, T> action)
        {
            using (var dbContext = GetRequiredService<IPermissionManagementDbContext>())
            {
                return action.Invoke(dbContext);
            }
        }
    }
}
