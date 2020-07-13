using Skuo.Snowflake;
using System;
using Volo.Abp.DependencyInjection;

namespace Skuo.Identity.Test
{
    public class IdentityTestData : ISingletonDependency
    {

        private readonly IIdGenerator _idGenerator;

        public IdentityTestData(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
            this.RoleModeratorId = _idGenerator.NextId();
            this.UserJohnId = _idGenerator.NextId();
            this.UserDavidId = _idGenerator.NextId();
            this.UserNeoId = _idGenerator.NextId();
            this.AgeClaimId = _idGenerator.NextId();
            this.EducationClaimId = _idGenerator.NextId();
        }

        public long RoleModeratorId { get; } // Guid.NewGuid();

        public long UserJohnId { get; } //= Guid.NewGuid();
        public long UserDavidId { get; } //= Guid.NewGuid();
        public long UserNeoId { get; } //= Guid.NewGuid();
        public long AgeClaimId { get; } //= Guid.NewGuid();
        public long EducationClaimId { get; } //= Guid.NewGuid();
    }
}
