using Microsoft.AspNetCore.Identity;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using Xunit;

namespace Skuo.Identity.Test
{
    public class RoleChangingEvents_Test : SkuoIdentityDomainTestBase
    {
        protected readonly IIdentityRoleRepository RoleRepository;
        protected readonly IdentityRoleManager RoleManager;
        protected readonly ILookupNormalizer LookupNormalizer;
        protected readonly IGuidGenerator GuidGenerator;
        protected readonly IUnitOfWorkManager UowManager;

        public RoleChangingEvents_Test()
        {
            RoleRepository = GetRequiredService<IIdentityRoleRepository>(); ;
            RoleManager = GetRequiredService<IdentityRoleManager>(); ;
            LookupNormalizer = GetRequiredService<ILookupNormalizer>(); ;
            GuidGenerator = GetRequiredService<IGuidGenerator>();
            UowManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Role_Update_Event_Test()
        {
            var role = await RoleRepository
                                .FindByNormalizedNameAsync(LookupNormalizer.NormalizeName("moderator"))
                                ;

           

            using (var uow = UowManager.Begin())
            {
                var identityResult = await RoleManager.SetRoleNameAsync(role, "TestModerator");
                identityResult.Succeeded.ShouldBeTrue();
                var xx = await RoleRepository.UpdateAsync(role);
                await uow.CompleteAsync();
            }

            role = await RoleRepository.GetAsync(role.Id);
            role.Name.ShouldBe("TestModerator");
        }
    }
}
