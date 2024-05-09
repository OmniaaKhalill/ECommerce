using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(p => p.Category, o => o.MapFrom(s => s.Category.name))
                .ForMember(p => p.seller, o => o.MapFrom(s => s.seller.Name))
                .ForMember(p => p.image_link, o => o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
