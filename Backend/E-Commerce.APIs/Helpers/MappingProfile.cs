using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;

namespace E_Commerce.APIs.Helpers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<AppUser, UserDto>()
                 .ForMember(d => d.Id, o => o.MapFrom(S => S.Id))
             .ForMember(d => d.DisplayName, o => o.MapFrom(S => S.DisplayName))
              .ForMember(d => d.Email, o => o.MapFrom(S => S.Email))
              .ForMember(d=>d.UserName, o => o.MapFrom(S => S.UserName))
               .ForMember(d => d.PhoneNumber, o => o.MapFrom(S => S.PhoneNumber))
               .ForMember(d => d.Password, o => o.MapFrom(S => S.PasswordHash))
              .ForMember(d => d.Address, o => o.MapFrom(S => S.Address))
              ;



            CreateMap<AppUser, UserToReturnDTO>()
               
            .ForMember(d => d.DisplayName, o => o.MapFrom(S => S.DisplayName))
             .ForMember(d => d.Email, o => o.MapFrom(S => S.Email))
             .ForMember(d => d.UserName, o => o.MapFrom(S => S.UserName))
              .ForMember(d => d.PhoneNumber, o => o.MapFrom(S => S.PhoneNumber))
              .ForMember(d => d.Password, o => o.MapFrom(S => S.PasswordHash))
             .ForMember(d => d.Address, o => o.MapFrom(S => S.Address));



            CreateMap<Review,ReviewsToReturnDto>()
                 .ForMember(d => d.UserName, o => o.MapFrom(S => S.User.UserName))
                .ForMember(d => d.Content, o => o.MapFrom(S => S.Content))
             .ForMember(d => d.Rating, o => o.MapFrom(S => S.Rating))
                .ForMember(d => d.DatePosted, o => o.MapFrom(S => S.DatePosted));

            CreateMap<Review, ReviewsDto>()
                .ForMember(d => d.Content, o => o.MapFrom(S => S.Content))
                .ForMember(d => d.Rating, o => o.MapFrom(S => S.Rating))
               
                ;

            CreateMap<Page, PageToReturnDto>()
                .ForMember(d => d.PageDescription, o => o.MapFrom(S => S.Description))
                .ForMember(d => d.PageName, o => o.MapFrom(S => S.name));

            CreateMap<Product, ProductToReturnDto>()
                 .ForMember(p => p.Brands, o => o.MapFrom(s => s.Brands.name))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.name))
                       .ForMember(dest => dest.seller, opt => opt.MapFrom(src => src.seller.name))
                       .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.Colors.Select(c => new ColorDto { Id = c.Id, hex_value = c.hex_value, colour_name=c.colour_name })))
                        .ForMember(p => p.Category, o => o.MapFrom(s => s.Category.name))
                        .ForMember(p => p.seller, o => o.MapFrom(s => s.seller.name))
                        .ForMember(p => p.image_link, o => o.MapFrom<ProductPictureUrlResolver>())
                        .ForMember(p=>p.Reviews, o => o.MapFrom(s=>s.Reviews.Select(c=> new ReviewsDto
                        {
                                Content = c.Content,
                                Rating = c.Rating,
                                DatePosted = c.DatePosted,
                                UserId = c.UserId,



                        })))
                        .ForMember(p => p.Colors, o => o.MapFrom(s => s.Colors.Select(c => new ColorDto
                        {
                            Id = c.Id,
                            hex_value = c.hex_value,
                            colour_name = c.colour_name
                        })));
           

            CreateMap<ProductToUpdateDto, Product>()
       .ForMember(dest => dest.Category, opt => opt.Ignore()) // Assuming you don't want to map this
       .ForMember(dest => dest.seller, opt => opt.Ignore()) // Assuming you don't want to map this
       .ForMember(dest => dest.Colors, opt => opt.Ignore());


            CreateMap<ReviewsDto, Review>()
                .ForMember(d => d.Content, o => o.MapFrom(S => S.Content))
                .ForMember(d => d.Rating, o => o.MapFrom(S => S.Rating))
                .ForMember(d => d.UserId, o => o.MapFrom(S => S.UserId))
                 .ForMember(d => d.ProductId, o => o.MapFrom(S => S.ProductId));




            CreateMap<UserDto ,AppUser >()
                  .ForMember(d => d.Id, o => o.MapFrom(S => S.Id))
           .ForMember(d => d.DisplayName, o => o.MapFrom(S => S.DisplayName))
            .ForMember(d => d.Email, o => o.MapFrom(S => S.Email))
            .ForMember(d => d.UserName, o => o.MapFrom(S => S.UserName))
             .ForMember(d => d.PhoneNumber, o => o.MapFrom(S => S.PhoneNumber))
             .ForMember(d => d.PasswordHash, o => o.MapFrom(S => S.Password))
            .ForMember(d => d.Address, o => o.MapFrom(S => S.Address))
            ;
        

                      
                   
            CreateMap<CustomerCartDto,customerCart>();
            CreateMap<CartItemDto, CartItem>();
            CreateMap<Category, CategoriesDto>()
                .ForMember(d => d.name, o => o.MapFrom(S => S.name))
                .ForMember(d => d.id, o => o.MapFrom(S => S.id));

            CreateMap<Brands, BrandsDto>()
                    .ForMember(d => d.name, o => o.MapFrom(S => S.name));



            CreateMap<Product, ProductSellerDto>().ForMember(p => p.Category, o => o.MapFrom(s => s.Category.name));





        }
    } 
}
