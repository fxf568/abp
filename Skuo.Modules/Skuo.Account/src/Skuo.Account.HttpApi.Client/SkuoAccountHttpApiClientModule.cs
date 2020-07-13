using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Skuo.Account
{
    [DependsOn(
        typeof(SkuoAccountApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SkuoAccountHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(SkuoAccountApplicationContractsModule).Assembly, 
                AccountRemoteServiceConsts.RemoteServiceName);
        }
    }
}