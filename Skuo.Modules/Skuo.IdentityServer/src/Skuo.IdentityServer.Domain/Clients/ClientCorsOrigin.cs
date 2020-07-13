using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientCorsOrigin : Entity
    {
        public virtual long ClientId { get; protected set; }

        public virtual string Origin { get; protected set; }

        protected ClientCorsOrigin()
        {

        }

        public virtual bool Equals(long clientId, [NotNull] string uri)
        {
            return ClientId == clientId && Origin == uri;
        }

        protected internal ClientCorsOrigin(long clientId, [NotNull] string origin)
        {
            Check.NotNull(origin, nameof(origin));

            ClientId = clientId;
            Origin = origin;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, Origin };
        }
    }
}