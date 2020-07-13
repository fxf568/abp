using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Skuo.Identity;
using Skuo.Snowflake;

namespace Skuo.IdentityServer.IdentityResources
{
    public class IdentityResourceDataSeeder : IIdentityResourceDataSeeder, ITransientDependency
    {
        protected IIdentityClaimTypeRepository ClaimTypeRepository { get; }
        protected IIdentityResourceRepository IdentityResourceRepository { get; }
        protected IIdGenerator IdGenerator { get; }

        public IdentityResourceDataSeeder(
            IIdentityResourceRepository identityResourceRepository,
            IIdGenerator idGenerator,
            IIdentityClaimTypeRepository claimTypeRepository)
        {
            IdentityResourceRepository = identityResourceRepository;
            IdGenerator = idGenerator;
            ClaimTypeRepository = claimTypeRepository;
        }

        public virtual async Task CreateStandardResourcesAsync()
        {
            var resources = new[]
            {
                new IdentityServer4.Models.IdentityResources.OpenId(),
                new IdentityServer4.Models.IdentityResources.Profile(),
                new IdentityServer4.Models.IdentityResources.Email(),
                new IdentityServer4.Models.IdentityResources.Address(),
                new IdentityServer4.Models.IdentityResources.Phone(),
                new IdentityServer4.Models.IdentityResource("role", "Roles of the user", new[] {"role"})
            };

            foreach (var resource in resources)
            {
                foreach (var claimType in resource.UserClaims)
                {
                    await AddClaimTypeIfNotExistsAsync(claimType);
                }

                await AddIdentityResourceIfNotExistsAsync(resource);
            }
        }

        protected virtual async Task AddIdentityResourceIfNotExistsAsync(IdentityServer4.Models.IdentityResource resource)
        {
            if (await IdentityResourceRepository.CheckNameExistAsync(resource.Name))
            {
                return;
            }

            await IdentityResourceRepository.InsertAsync(
                new IdentityResource(
                    IdGenerator.NextId(),
                    resource
                )
            );
        }

        protected virtual async Task AddClaimTypeIfNotExistsAsync(string claimType)
        {
            if (await ClaimTypeRepository.AnyAsync(claimType))
            {
                return;
            }

            await ClaimTypeRepository.InsertAsync(
                new IdentityClaimType(
                    IdGenerator.NextId(),
                    claimType,
                    isStatic: true
                )
            );
        }
    }
}
