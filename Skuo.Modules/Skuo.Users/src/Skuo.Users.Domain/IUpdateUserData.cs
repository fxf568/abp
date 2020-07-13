using JetBrains.Annotations;

namespace Skuo.Users
{
    public interface IUpdateUserData
    {
        bool Update([NotNull] IUserData user);
    }

}