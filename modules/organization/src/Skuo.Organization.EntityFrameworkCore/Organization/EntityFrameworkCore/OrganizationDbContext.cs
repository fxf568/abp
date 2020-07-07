using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Skuo.Organization.EntityFrameworkCore
{
    [ConnectionStringName("OrganizationService")]
    public class OrganizationDbContext : AbpDbContext<OrganizationDbContext>, IOrganizationDbContext
    {
        public static string TablePrefix { get; set; } = OrganizationConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = OrganizationConsts.DefaultDbSchema;

        public DbSet<OrganizationUnit> AbpOrganizations { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }

        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureOrganizationService(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}