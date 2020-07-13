using System.ComponentModel.DataAnnotations;

namespace Skuo.Identity
{
    public class IdentityUserUpdateRolesDto
    {
        [Required]
        public string[] RoleNames { get; set; }
    }
}