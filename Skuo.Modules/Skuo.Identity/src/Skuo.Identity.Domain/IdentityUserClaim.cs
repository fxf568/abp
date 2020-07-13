using System;
using System.Security.Claims;
using JetBrains.Annotations;

namespace Skuo.Identity
{
    /// <summary>
    /// Represents a claim that a user possesses. 
    /// </summary>
    public class IdentityUserClaim : IdentityClaim
    {
        /// <summary>
        /// Gets or sets the primary key of the user associated with this claim.
        /// </summary>
        public virtual long UserId { get; protected set; }

        protected IdentityUserClaim()
        {

        }

        protected internal IdentityUserClaim(long id, long userId, [NotNull] Claim claim, Guid? tenantId)
            : base(id, claim, tenantId)
        {
            UserId = userId;
        }

        public IdentityUserClaim(long id, long userId, [NotNull] string claimType, string claimValue, Guid? tenantId)
            : base(id, claimType, claimValue, tenantId)
        {
            UserId = userId;
        }
    }
}