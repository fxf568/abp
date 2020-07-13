using System;
using JetBrains.Annotations;

namespace Skuo.IdentityServer.ApiResources
{
    public class ApiResourceClaim : UserClaim
    {
        public virtual long ApiResourceId { get; set; }

        protected ApiResourceClaim()
        {

        }

        public virtual bool Equals(long apiResourceId, [NotNull] string type)
        {
            return ApiResourceId == apiResourceId && Type == type;
        }

        protected internal ApiResourceClaim(long apiResourceId, [NotNull] string type)
            : base(type)
        {
            ApiResourceId = apiResourceId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ApiResourceId, Type};
        }
    }
}