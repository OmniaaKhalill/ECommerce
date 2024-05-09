using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class ProductToCreateDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public int? CategoryId { get; set; }
        public List<Coulor> Colors { get; set; }
        public List<Tag> TagList { get; set; }
        public int NumOfProductInStock { get; set; }
    }
}
