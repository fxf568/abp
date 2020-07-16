﻿using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Skuo.PermissionManagement
{
    //TODO: To aggregate root?
    public class PermissionGrant : Entity<long>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string ProviderName { get; protected set; }

        [CanBeNull]
        public virtual string ProviderKey { get; protected internal set; }

        protected PermissionGrant()
        {

        }

        public PermissionGrant(
            long id,
            [NotNull] string name,
            [NotNull] string providerName ,
            [CanBeNull] string providerKey,
            Guid? tenantId = null)
        {
            Check.NotNull(name, nameof(name));

            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            ProviderName = Check.NotNullOrWhiteSpace(providerName, nameof(providerName));
            ProviderKey = providerKey;
            TenantId = tenantId;
        }
    }
}
