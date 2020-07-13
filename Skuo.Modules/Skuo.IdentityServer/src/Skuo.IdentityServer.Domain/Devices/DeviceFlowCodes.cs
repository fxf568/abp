using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Skuo.IdentityServer.Devices
{
    public class DeviceFlowCodes : CreationAuditedAggregateRoot<long>
    {
        public virtual string DeviceCode { get; set; }

        public virtual string UserCode { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual string Data { get; set; }

        protected DeviceFlowCodes()
        {

        }

        public DeviceFlowCodes(long id)
        : base(id)
        {

        }
    }
}