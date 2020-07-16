using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Volo.Abp.Users;

namespace Skuo.PermissionManagement
{
    public class SkuoPermissionManagementApplicationTestBase : PermissionManagementTestBase<SkuoPermissionManagementApplicationTestModule>
    {
        protected Guid? CurrentUserId { get; set; }

        protected SkuoPermissionManagementApplicationTestBase()
        {
            CurrentUserId = Guid.NewGuid();
        }
        protected override void AfterAddApplication(IServiceCollection services)
        {
            var currentUser = Substitute.For<ICurrentUser>();
            //currentUser.Id.Returns(ci => CurrentUserId);
            currentUser.IsAuthenticated.Returns(true);

            services.AddSingleton(currentUser);
        }
    }
}
