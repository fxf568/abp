using System;
using JetBrains.Annotations;

namespace Skuo.IdentityServer.IdentityResources
{
    public class IdentityClaim : UserClaim
    {
        public virtual long IdentityResourceId { get; set; }

        protected IdentityClaim()
        {

        }

        public virtual bool Equals(long identityResourceId, [NotNull] string type)
        {
            return IdentityResourceId == identityResourceId && Type == type;
        }

        protected internal IdentityClaim(long identityResourceId, [NotNull] string type)
            : base(type)
        {
            IdentityResourceId = identityResourceId;
        }

        public override object[] GetKeys()
        {
            return new object[] { IdentityResourceId, Type };
        }
    }
}