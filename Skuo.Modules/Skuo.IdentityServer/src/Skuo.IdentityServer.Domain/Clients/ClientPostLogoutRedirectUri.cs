using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientPostLogoutRedirectUri : Entity
    {
        public virtual long ClientId { get; protected set; }

        public virtual string PostLogoutRedirectUri { get; protected set; }
        
        protected ClientPostLogoutRedirectUri()
        {

        }

        public virtual bool Equals(long clientId, [NotNull] string uri)
        {
            return ClientId == clientId && PostLogoutRedirectUri == uri;
        }

        protected internal ClientPostLogoutRedirectUri(long clientId, [NotNull] string postLogoutRedirectUri)
        {
            Check.NotNull(postLogoutRedirectUri, nameof(postLogoutRedirectUri));

            ClientId = clientId;
            PostLogoutRedirectUri = postLogoutRedirectUri;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, PostLogoutRedirectUri };
        }
    }
}