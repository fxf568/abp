using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Skuo.Organization
{
    [DependsOn(
        typeof(OrganizationApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class OrganizationHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Organization";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(OrganizationApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
