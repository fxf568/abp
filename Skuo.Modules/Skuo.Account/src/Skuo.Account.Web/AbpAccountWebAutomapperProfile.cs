using Skuo.Account.Web.Pages.Account;
using Skuo.Identity;
using AutoMapper;

namespace Skuo.Account.Web
{
    public class AbpAccountWebAutoMapperProfile : Profile
    {
        public AbpAccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
