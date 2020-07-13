using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;
using Volo.Abp.Uow;
using Volo.Abp.Settings;
using Skuo.Identity.Settings;
using Volo.Abp;

namespace Skuo.Identity
{
    public class IdentityUserManager : UserManager<IdentityUser>, IDomainService
    {
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IIdentityUserRepository UserRepository { get; }
        protected ISettingProvider SettingProvider { get; }
        protected ICancellationTokenProvider CancellationTokenProvider { get; }

        protected override CancellationToken CancellationToken => CancellationTokenProvider.Token;

        public IdentityUserManager(
            IdentityUserStore store,
            IIdentityRoleRepository roleRepository,
            IIdentityUserRepository userRepository,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<IdentityUserManager> logger,
            ICancellationTokenProvider cancellationTokenProvider,
            ISettingProvider settingProvider)
            : base(
                  store,
                  optionsAccessor,
                  passwordHasher,
                  userValidators,
                  passwordValidators,
                  keyNormalizer,
                  errors,
                  services,
                  logger)
        {
            SettingProvider = settingProvider;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            CancellationTokenProvider = cancellationTokenProvider;
        }

        public virtual async Task<IdentityUser> GetByIdAsync(long id)
        {
            var user = await Store.FindByIdAsync(id.ToString(), CancellationToken);
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(IdentityUser), id);
            }

            return user;
        }

        public virtual async Task<IdentityResult> SetRolesAsync([NotNull] IdentityUser user, [NotNull] IEnumerable<string> roleNames)
        {
            Check.NotNull(user, nameof(user));
            Check.NotNull(roleNames, nameof(roleNames));

            var currentRoleNames = await GetRolesAsync(user);

            var result = await RemoveFromRolesAsync(user, currentRoleNames.Except(roleNames).Distinct());
            if (!result.Succeeded)
            {
                return result;
            }

            result = await AddToRolesAsync(user, roleNames.Except(currentRoleNames).Distinct());
            if (!result.Succeeded)
            {
                return result;
            }

            return IdentityResult.Success;
        }
        public virtual async Task<IdentityResult> AddDefaultRolesAsync([NotNull] IdentityUser user)
        {
            await UserRepository.EnsureCollectionLoadedAsync(user, u => u.Roles, CancellationToken);

            foreach (var role in await RoleRepository.GetDefaultOnesAsync(cancellationToken: CancellationToken))
            {
                if (!user.IsInRole(role.Id))
                {
                    user.AddRole(role.Id);
                }
            }

            return await UpdateUserAsync(user);
        }
    }
}
