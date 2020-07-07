using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Skuo.Organization.EntityFrameworkCore
{
    [ConnectionStringName("OrganizationService")]
    public interface IOrganizationDbContext : IEfCoreDbContext
    {
        DbSet<OrganizationUnit> AbpOrganizations { get; }

        DbSet<UserOrganization> UserOrganizations { get; }
    }
}