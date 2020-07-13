using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using JetBrains.Annotations;
using Skuo.Snowflake;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Skuo.Identity
{
    /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    public class IdentityRole : AggregateRoot<long>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        public virtual string Name { get; protected internal set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        [DisableAuditing]
        public virtual string NormalizedName { get; protected internal set; }

        /// <summary>
        /// Navigation property for claims in this role.
        /// </summary>
        public virtual ICollection<IdentityRoleClaim> Claims { get; protected set; }

        /// <summary>
        /// A default role is automatically assigned to a new user
        /// </summary>
        public virtual bool IsDefault { get; set; }

        /// <summary>
        /// A static role can not be deleted/renamed
        /// </summary>
        public virtual bool IsStatic { get; set; }

        /// <summary>
        /// A user can see other user's public roles
        /// </summary>
        public virtual bool IsPublic { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        protected IdentityRole() { }

        public IdentityRole(long id, [NotNull] string name, Guid? tenantId = null)
        {
            Check.NotNull(name, nameof(name));

            Id = id;
            Name = name;
            TenantId = tenantId;
            NormalizedName = name.ToUpperInvariant();
            ConcurrencyStamp = Guid.NewGuid().ToString();

            Claims = new Collection<IdentityRoleClaim>();
        }

        public virtual void AddClaim([NotNull] IIdGenerator idGenerator, [NotNull] Claim claim)
        {

            Check.NotNull(claim, nameof(claim));

            Claims.Add(new IdentityRoleClaim(idGenerator.NextId(), Id, claim, TenantId));
        }

        public virtual void AddClaims([NotNull] IIdGenerator idGenerator, [NotNull] IEnumerable<Claim> claims)
        {
            Check.NotNull(idGenerator, nameof(idGenerator));
            Check.NotNull(claims, nameof(claims));

            foreach (var claim in claims)
            {
                AddClaim(idGenerator, claim);
            }
        }

        public virtual IdentityRoleClaim FindClaim([NotNull] Claim claim)
        {
            Check.NotNull(claim, nameof(claim));

            return Claims.FirstOrDefault(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value);
        }

        public virtual void RemoveClaim([NotNull] Claim claim)
        {
            Check.NotNull(claim, nameof(claim));

            Claims.RemoveAll(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value);
        }

        public virtual void ChangeName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var oldName = Name;
            Name = name;

            AddLocalEvent(
                new IdentityRoleNameChangedEvent
                {
                    IdentityRole = this,
                    OldName = oldName
                }
            );
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Name = {Name}";
        }
    }
}
