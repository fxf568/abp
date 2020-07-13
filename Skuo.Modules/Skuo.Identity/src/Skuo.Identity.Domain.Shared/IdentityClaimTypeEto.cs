using System;

namespace Skuo.Identity
{
    [Serializable]
    public class IdentityClaimTypeEto<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public bool IsStatic { get; set; }

        public string Regex { get; set; }

        public string RegexDescription { get; set; }

        public string Description { get; set; }

        public IdentityClaimValueType ValueType { get; set; }
    }
    [Serializable]
    public class IdentityClaimTypeEto : IdentityClaimTypeEto<long>
    { }
}
