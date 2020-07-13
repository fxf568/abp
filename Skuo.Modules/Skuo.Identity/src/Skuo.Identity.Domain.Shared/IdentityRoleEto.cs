using System;

namespace Skuo.Identity
{
    [Serializable]
    public class IdentityRoleEto<TKey>
    {
        public TKey Id { get; set; }

        public Guid? TenantId { get; set; }

        public string Name { get; set; }
        
        public bool IsDefault { get; set; }

        public bool IsStatic { get; set; }
        
        public bool IsPublic { get; set; }
    }
    [Serializable]
    public class IdentityRoleEto : IdentityRoleEto<long>
    {
        
    }
}