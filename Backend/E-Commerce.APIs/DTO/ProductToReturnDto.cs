using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string ImageLink { get; set; }

        public int? CategoryId { get; set; }
        public string Category { get; set; }

        //public List<string>? ColorNames { get; set; }
        //public List<int>? ColorIds { get; set; }

        public List<ColorDto> Colors { get; set; }


        public string SellerId { get; set; }
        public string Seller { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public int NumOfProductInStock { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public List<Cart> Carts { get; set; }

        public List<WishList> WishLists { get; set; }
    }

}
