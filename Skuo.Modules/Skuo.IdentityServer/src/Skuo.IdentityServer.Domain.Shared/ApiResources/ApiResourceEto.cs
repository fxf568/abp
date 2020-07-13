using System;
using JetBrains.Annotations;

namespace Skuo.IdentityServer.ApiResources
{
    [Serializable]
    public class ApiResourceEto
    {
        public long Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
    }
}