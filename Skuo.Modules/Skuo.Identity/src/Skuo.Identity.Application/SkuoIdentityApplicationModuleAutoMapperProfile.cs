using AutoMapper;

namespace Skuo.Identity
{
    public class SkuoIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public SkuoIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentityUser, IdentityUserDto>()
                .MapExtraProperties();

            CreateMap<IdentityRole, IdentityRoleDto>()
                .MapExtraProperties();
            
            CreateMap<IdentityUser, ProfileDto>()
                .MapExtraProperties();
        }
    }
}