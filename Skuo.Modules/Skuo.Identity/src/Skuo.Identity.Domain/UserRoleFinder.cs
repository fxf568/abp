using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Skuo.Identity
{
    public class UserRoleFinder : IUserRoleFinder, ITransientDependency
    {
        protected IIdentityUserRepository IdentityUserRepository { get; }

        public UserRoleFinder(IIdentityUserRepository identityUserRepository)
        {
            IdentityUserRepository = identityUserRepository;
        }

        public virtual async Task<string[]> GetRolesAsync(long userId)
        {
            return (await IdentityUserRepository.GetRoleNamesAsync(userId)).ToArray();
        }
    }
}
