using System.Threading.Tasks;

namespace Skuo.IdentityServer.IdentityResources
{
    public interface IIdentityResourceDataSeeder
    {
        Task CreateStandardResourcesAsync();
    }
}