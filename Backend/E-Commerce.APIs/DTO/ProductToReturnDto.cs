using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class ProductToReturnDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }

        public string image_link { get; set; }

        public int CategoryId { get; set; }
        public string? Category { get; set; }

        public List<ColorDto>? Colors { get; set; }


        public string SellerId { get; set; }
        public string? seller { get; set; }


        public virtual ICollection<ReviewsDto>? Reviews { get; set; }


        public int NumOfProductInStock { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
        public List<Cart>? Carts { get; set; }


        public List<WishList>? WishLists { get; set; }

    }

}
