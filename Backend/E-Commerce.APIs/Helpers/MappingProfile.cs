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

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(p => p.Category, o => o.MapFrom(s => s.Category.name))
                .ForMember(p => p.Seller, o => o.MapFrom(s => s.seller.name))
                .ForMember(p => p.ImageLink, o => o.MapFrom<ProductPictureUrlResolver>())
                .ForMember(p => p.Colors, o => o.MapFrom(s => s.Colors.Select(c => new ColorDto
                {
                    Id = c.Id,
                    HexValue = c.hex_value,
                    ColourName = c.colour_name
                })));
        }


    }
}
