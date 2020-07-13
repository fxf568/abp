using System;
using System.Threading.Tasks;

namespace Skuo.Identity
{
    public interface IUserRoleFinder
    {
        Task<string[]> GetRolesAsync(long userId);
    }
}
