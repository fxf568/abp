using AutoMapper;
using Volo.Abp.AutoMapper;

namespace Skuo.Organization
{
    public class OrganizationApplicationAutoMapperProfile : Profile
    {
        public OrganizationApplicationAutoMapperProfile()
        {
            CreateMap<OrganizationUnit, OrganizationDto>();
            CreateMap<CreateUpdateAbpOrganizationDto, OrganizationUnit>();
            
        }
    }
}