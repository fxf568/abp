using Volo.Abp.Application.Dtos;

namespace Skuo.Identity
{
    public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
