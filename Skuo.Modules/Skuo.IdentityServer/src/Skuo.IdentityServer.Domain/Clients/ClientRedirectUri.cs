using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientRedirectUri : Entity
    {
        public virtual long ClientId { get; protected set; }

        public virtual string RedirectUri { get; protected set; }

        protected ClientRedirectUri()
        {

        }

        public virtual bool Equals(long clientId, [NotNull] string uri)
        {
            return ClientId == clientId && RedirectUri == uri;
        }

        protected internal ClientRedirectUri(long clientId, [NotNull] string redirectUri)
        {
            Check.NotNull(redirectUri, nameof(redirectUri));

            ClientId = clientId;
            RedirectUri = redirectUri;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, RedirectUri };
        }
    }
}