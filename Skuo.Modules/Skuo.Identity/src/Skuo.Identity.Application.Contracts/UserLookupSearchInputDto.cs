using Volo.Abp.Application.Dtos;

namespace Skuo.Identity
{
    public class UserLookupSearchInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}