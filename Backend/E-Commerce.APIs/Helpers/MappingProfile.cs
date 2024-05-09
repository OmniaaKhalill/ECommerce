using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.Helpers
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Page, PageToReturnDto>()
             .ForMember(d => d.PageDescription, o => o.MapFrom(S => S.Description))
             .ForMember(d => d.PageName, o => o.MapFrom(S => S.name));

        }

    }
}
