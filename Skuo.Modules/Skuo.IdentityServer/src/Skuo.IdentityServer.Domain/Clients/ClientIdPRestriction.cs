using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientIdPRestriction : Entity
    {
        public virtual long ClientId { get; set; }

        public virtual string Provider { get; set; }

        protected ClientIdPRestriction()
        {

        }

        public virtual bool Equals(long clientId, [NotNull] string provider)
        {
            return ClientId == clientId && Provider == provider;
        }

        protected internal ClientIdPRestriction(long clientId, [NotNull] string provider)
        {
            Check.NotNull(provider, nameof(provider));

            ClientId = clientId;
            Provider = provider;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, Provider };
        }
    }
}