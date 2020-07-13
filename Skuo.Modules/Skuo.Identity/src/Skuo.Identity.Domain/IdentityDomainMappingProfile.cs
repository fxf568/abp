using AutoMapper;
using Skuo.Users;

namespace Skuo.Identity
{
    public class IdentityDomainMappingProfile : Profile
    {
        public IdentityDomainMappingProfile()
        {
            CreateMap<IdentityUser, UserEto>();
            CreateMap<IdentityClaimType, IdentityClaimTypeEto>();
            CreateMap<IdentityRole, IdentityRoleEto>();
        }
    }
}