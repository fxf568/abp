using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Skuo.Identity;

namespace Skuo.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);
    }
}