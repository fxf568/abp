using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Skuo.Identity;
using Skuo.IdentityServer.ApiResources;
using Skuo.IdentityServer.Clients;
using Skuo.IdentityServer.Devices;
using Skuo.IdentityServer.IdentityResources;
using Skuo.IdentityServer.Tokens;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Security;
using Volo.Abp.Validation;
using Volo.Abp;

namespace Skuo.IdentityServer
{
    [DependsOn(
        typeof(SkuoIdentityServerDomainSharedModule),
        typeof(AbpAutoMapperModule),
        typeof(SkuoIdentityDomainModule),
        typeof(AbpSecurityModule),
        typeof(AbpCachingModule),
        typeof(AbpValidationModule),
        typeof(AbpBackgroundWorkersModule),
        typeof(Snowflake.SkuoSnowflakeModule)
        )]
    public class SkuoIdentityServerDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SkuoIdentityServerDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<IdentityServerAutoMapperProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<ApiResource, ApiResourceEto>(typeof(SkuoIdentityServerDomainModule));
                options.EtoMappings.Add<Client, ClientEto>(typeof(SkuoIdentityServerDomainModule));
                options.EtoMappings.Add<DeviceFlowCodes, DeviceFlowCodesEto>(typeof(SkuoIdentityServerDomainModule));
                options.EtoMappings.Add<IdentityResource, IdentityResourceEto>(typeof(SkuoIdentityServerDomainModule));
            });

            AddIdentityServer(context.Services);
        }

        private static void AddIdentityServer(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            var builderOptions = services.ExecutePreConfiguredActions<SkuoIdentityServerBuilderOptions>();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            });

            if (builderOptions.AddDeveloperSigningCredential)
            {
                identityServerBuilder = identityServerBuilder.AddAbpDeveloperSigningCredential();
            }

            identityServerBuilder.AddAbpIdentityServer(builderOptions);

            services.ExecutePreConfiguredActions(identityServerBuilder);

            if (!services.IsAdded<IPersistedGrantService>())
            {
                services.TryAddSingleton<IPersistedGrantStore, InMemoryPersistedGrantStore>();
            }

            if (!services.IsAdded<IDeviceFlowStore>())
            {
                services.TryAddSingleton<IDeviceFlowStore, InMemoryDeviceFlowStore>();
            }

            if (!services.IsAdded<IClientStore>())
            {
                identityServerBuilder.AddInMemoryClients(configuration.GetSection("IdentityServer:Clients"));
            }

            if (!services.IsAdded<IResourceStore>())
            {
                identityServerBuilder.AddInMemoryApiResources(configuration.GetSection("IdentityServer:ApiResources"));
                identityServerBuilder.AddInMemoryIdentityResources(configuration.GetSection("IdentityServer:IdentityResources"));
            }
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.Client,
                typeof(Client)
            );

            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.IdentityResource,
                typeof(IdentityResource)
            );

            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.ApiResource,
                typeof(ApiResource)
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<TokenCleanupOptions>>().Value;
            if (options.IsCleanupEnabled)
            {
                context.ServiceProvider
                    .GetRequiredService<IBackgroundWorkerManager>()
                    .Add(
                        context.ServiceProvider
                            .GetRequiredService<TokenCleanupBackgroundWorker>()
                    );
            }
        }
    }
}
