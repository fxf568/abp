using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Skuo.Organization.EntityFrameworkCore
{
    [DependsOn(
        typeof(OrganizationDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class OrganizationEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OrganizationDbContext>(options =>
            {
                options.AddDefaultRepositories<IOrganizationDbContext>(true);

                options.AddRepository<OrganizationUnit, EfCoreOrganizationRepository>();

            });

       
        }
    }
}