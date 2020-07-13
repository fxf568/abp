using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Skuo.Snowflake;
using Volo.Abp;
using Xunit;

namespace Skuo.Identity.Test
{
    public class IdenityClaimTypeManager_Tests : SkuoIdentityDomainTestBase
    {
        private readonly IIdentityClaimTypeRepository _identityClaimTypeRepository;
        private readonly IdenityClaimTypeManager _claimTypeManager;
        private readonly IdentityTestData _testData;
        private readonly IIdGenerator _idGenerator;

        public IdenityClaimTypeManager_Tests()
        {
            _idGenerator= GetRequiredService<IIdGenerator>();
            _identityClaimTypeRepository = GetRequiredService<IIdentityClaimTypeRepository>();
            _claimTypeManager = GetRequiredService<IdenityClaimTypeManager>();
            _testData = GetRequiredService<IdentityTestData>();
        }

        [Fact]
        public async Task CreateAsync()
        {
            var claimType = await _claimTypeManager.CreateAsync(new IdentityClaimType(_idGenerator.NextId(), "Phone", false,
                false, null,
                null, null, IdentityClaimValueType.String));

            claimType.ShouldNotBeNull();
            claimType.Name.ShouldBe("Phone");
        }

        [Fact]
        public async Task Create_Name_Exist_Should_Exception()
        {
            await Assert.ThrowsAnyAsync<AbpException>(async () => await _claimTypeManager.CreateAsync(
                new IdentityClaimType(
                   _idGenerator.NextId(), "Age")));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var ageClaim = await _identityClaimTypeRepository.FindAsync(_testData.AgeClaimId);
            ageClaim.ShouldNotBeNull();
            ageClaim.Description = "this is age";

            var updatedAgeClaimType = await _claimTypeManager.UpdateAsync(ageClaim);
            updatedAgeClaimType.ShouldNotBeNull();
            updatedAgeClaimType.Description.ShouldBe("this is age");
        }


        [Fact]
        public async Task Update_Name_Exist_Should_Exception()
        {
            await Assert.ThrowsAnyAsync<AbpException>(async () => await _claimTypeManager.UpdateAsync(
                new IdentityClaimType(
                    _idGenerator.NextId(), "Age")));
        }


        [Fact]
        public async Task Static_IdentityClaimType_Cant_Not_Update()
        {
            var phoneClaim = new IdentityClaimType(_idGenerator.NextId(), "Phone", true, true);
            await _identityClaimTypeRepository.InsertAsync(phoneClaim);

            await Assert.ThrowsAnyAsync<AbpException>(async () => await _claimTypeManager.UpdateAsync(phoneClaim));
        }
    }
}
