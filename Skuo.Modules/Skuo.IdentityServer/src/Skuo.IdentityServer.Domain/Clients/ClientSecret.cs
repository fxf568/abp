using System;
using IdentityServer4;
using JetBrains.Annotations;

namespace Skuo.IdentityServer.Clients
{
    public class ClientSecret : Secret
    {
        public virtual long ClientId { get; protected set; }

        protected ClientSecret()
        {

        }

        protected internal ClientSecret(
            long clientId,
            [NotNull] string value,
            DateTime? expiration = null,
            string type = IdentityServerConstants.SecretTypes.SharedSecret,
            string description = null
            ) : base(
                  value, 
                  expiration, 
                  type, 
                  description)
        {
            ClientId = clientId;
        }

        public virtual bool Equals(long clientId, [NotNull] string value, string type = IdentityServerConstants.SecretTypes.SharedSecret)
        {
            return ClientId == clientId && Value == value && Type == type;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, Type, Value };
        }
    }
}