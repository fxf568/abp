using System;
using System.Security.Claims;
using JetBrains.Annotations;

namespace Skuo.Identity
{
    /// <summary>
    /// Represents a claim that is granted to all users within a role.
    /// </summary>
    public class IdentityRoleClaim : IdentityClaim
    {
        /// <summary>
        /// Gets or sets the of the primary key of the role associated with this claim.
        /// </summary>
        public virtual long RoleId { get; protected set; }

        protected IdentityRoleClaim()
        {

        }

        protected internal IdentityRoleClaim(
            long id,
            long roleId, 
            [NotNull] Claim claim,
            Guid? tenantId)
            : base(
                  id, 
                  claim,
                  tenantId)
        {
            RoleId = roleId;
        }

        public IdentityRoleClaim(
            long id,
            long roleId, 
            [NotNull] string claimType, 
            string claimValue,
            Guid? tenantId)
            : base(
                  id, 
                  claimType, 
                  claimValue,
                  tenantId)
        {
            RoleId = roleId;
        }
    }
}