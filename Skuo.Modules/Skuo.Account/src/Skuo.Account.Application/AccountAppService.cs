using Microsoft.AspNetCore.Identity;
using Skuo.Account;
using Skuo.Account.Settings;
using Skuo.Identity;
using Skuo.Snowflake;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace Volo.Abp.Account
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IdentityUserManager UserManager { get; }
        protected IIdGenerator IdGenerator { get; set; }
        public AccountAppService(
            IdentityUserManager userManager,
            IIdGenerator idGenerator,
            IIdentityRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
            UserManager = userManager;
            IdGenerator = idGenerator;
        }

        public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            await CheckSelfRegistrationAsync();

            var user = new IdentityUser(IdGenerator.NextId(), input.UserName, input.EmailAddress, CurrentTenant.Id);

            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();

            await UserManager.SetEmailAsync(user,input.EmailAddress);
            await UserManager.AddDefaultRolesAsync(user);

            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        protected virtual async Task CheckSelfRegistrationAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled))
            {
                throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
            }
        }
    }
}