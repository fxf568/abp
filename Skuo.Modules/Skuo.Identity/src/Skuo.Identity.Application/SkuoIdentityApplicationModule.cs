using Microsoft.Extensions.DependencyInjection;
using Skuo.Snowflake;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;


namespace Skuo.Identity
{
    [DependsOn(
        typeof(SkuoIdentityDomainModule),
        typeof(SkuoIdentityApplicationContractsModule),
        typeof(SkuoSnowflakeModule),
        typeof(AbpAutoMapperModule)
        )]
    public class SkuoIdentityApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SkuoIdentityApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SkuoIdentityApplicationModuleAutoMapperProfile>(validate: true);
            });
        }
    }
}