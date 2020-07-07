/*
* CLR版本:          4.0.30319.42000
* 命名空间名称/文件名:    OrganizationService/IOrganizationRepository
* 创建者：天上有木月
* 创建时间：2019/5/6 12:57:06
* 邮箱：igeekfan@foxmail.com
* 文件功能描述： 
* 
* 修改人： 
* 时间：
* 修改说明：
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Skuo.Organization
{
    public interface IOrganizationRepository : IBasicRepository<OrganizationUnit, Guid>
    {
        Task<List<OrganizationUnit>> GetOrganizationsAsync(Guid userId);
    }
}
