using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Clients
{
    public class ClientClaim : Entity
    {
        public virtual long ClientId { get; set; }

        public virtual string Type { get; set; }

        public virtual string Value { get; set; }

        protected ClientClaim()
        {

        }

        public virtual bool Equals(long clientId, string value, string type)
        {
            return ClientId == clientId && Type == type && Value == value;
        }

        protected internal ClientClaim(long clientId, [NotNull] string type, string value)
        {
            Check.NotNull(type, nameof(type));

            ClientId = clientId;
            Type = type;
            Value = value;
        }

        public override object[] GetKeys()
        {
            return new object[] { ClientId, Type, Value };
        }
    }
}