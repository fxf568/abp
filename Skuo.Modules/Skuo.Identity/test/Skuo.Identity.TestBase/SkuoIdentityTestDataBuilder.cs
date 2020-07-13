using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Skuo.Snowflake;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Skuo.Identity.Test
{
    public class SkuoIdentityTestDataBuilder : ITransientDependency
    {
        private readonly IIdGenerator _idGenerator;
        private readonly IIdentityUserRepository _userRepository;
        private readonly IIdentityClaimTypeRepository _identityClaimTypeRepository;
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly IdentityTestData _testData;

        private IdentityRole _adminRole;
        private IdentityRole _moderatorRole;
        private IdentityRole _supporterRole;
        private IdentityRole _managerRole;

        public SkuoIdentityTestDataBuilder(
            IIdGenerator idGenerator,
            IIdentityUserRepository userRepository,
            IIdentityClaimTypeRepository identityClaimTypeRepository,
            IIdentityRoleRepository roleRepository,
            ILookupNormalizer lookupNormalizer,
            IdentityTestData testData)
        {
            _idGenerator = idGenerator;
            _userRepository = userRepository;
            _identityClaimTypeRepository = identityClaimTypeRepository;
            _roleRepository = roleRepository;
            _lookupNormalizer = lookupNormalizer;
            _testData = testData;
        }

        public async Task Build()
        {
            await AddRoles();
            await AddUsers();
            await AddClaimTypes();
        }

        private async Task AddRoles()
        {
            _adminRole = await _roleRepository.FindByNormalizedNameAsync(_lookupNormalizer.NormalizeName("admin"));

            _moderatorRole = new IdentityRole(_testData.RoleModeratorId, "moderator");
            _moderatorRole.AddClaim(_idGenerator, new Claim("test-claim", "test-value"));
            await _roleRepository.InsertAsync(_moderatorRole);

            _supporterRole = new IdentityRole(_idGenerator.NextId(), "supporter");
            await _roleRepository.InsertAsync(_supporterRole);

            _managerRole = new IdentityRole(_idGenerator.NextId(), "manager");
            await _roleRepository.InsertAsync(_managerRole);
        }

       

        private async Task AddUsers()
        {
            var adminUser = new IdentityUser(_idGenerator.NextId(), "administrator", "admin@abp.io");
            adminUser.AddRole(_adminRole.Id);
            adminUser.AddClaim(_idGenerator, new Claim("TestClaimType", "42"));
            await _userRepository.InsertAsync(adminUser);

            var john = new IdentityUser(_testData.UserJohnId, "john.nash", "john.nash@abp.io");
            john.AddRole(_moderatorRole.Id);
            john.AddRole(_supporterRole.Id);
            john.AddRole(_managerRole.Id);
            john.AddLogin(new UserLoginInfo("github", "john", "John Nash"));
            john.AddLogin(new UserLoginInfo("twitter", "johnx", "John Nash"));
            john.AddClaim(_idGenerator, new Claim("TestClaimType", "42"));
            john.SetToken("test-provider", "test-name", "test-value");
            await _userRepository.InsertAsync(john);

            var david = new IdentityUser(_testData.UserDavidId, "david", "david@abp.io");
            await _userRepository.InsertAsync(david);

            var neo = new IdentityUser(_testData.UserNeoId, "neo", "neo@abp.io");
            neo.AddRole(_supporterRole.Id);
            neo.AddClaim(_idGenerator, new Claim("TestClaimType", "43"));
            await _userRepository.InsertAsync(neo);
        }


        private async Task AddClaimTypes()
        {
            var ageClaim = new IdentityClaimType(_testData.AgeClaimId, "Age", false, false, null, null, null, IdentityClaimValueType.Int);
            await _identityClaimTypeRepository.InsertAsync(ageClaim);

            var educationClaim = new IdentityClaimType(_testData.EducationClaimId, "Education", true, false, null, null, null);
            await _identityClaimTypeRepository.InsertAsync(educationClaim);
        }
    }
}