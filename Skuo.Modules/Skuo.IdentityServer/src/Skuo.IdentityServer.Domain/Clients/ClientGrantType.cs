using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientGrantType : Entity
    {
        public virtual long ClientId { get; protected set; }

        public virtual string GrantType { get; protected set; }

        protected ClientGrantType()
        {

        }

        public virtual bool Equals(long clientId, [NotNull] string grantType)
        {
            return ClientId == clientId && GrantType == grantType;
        }

        protected internal ClientGrantType(long clientId, [NotNull] string grantType)
        {
            Check.NotNull(grantType, nameof(grantType));

            ClientId = clientId;
            GrantType = grantType;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, GrantType };
        }
    }
}