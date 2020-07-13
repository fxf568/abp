using System;
using Volo.Abp.Domain.Entities;

namespace Skuo.IdentityServer.Grants
{
    /// <summary>
    /// 授权信息
    /// </summary>
    public class PersistedGrant : AggregateRoot<long>
    {
        public virtual string Key { get; set; }

        public virtual string Type { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual string Data { get; set; }

        protected PersistedGrant()
        {
            
        }

        public PersistedGrant(long id)
        {
            Id = id;
        }
    }
}