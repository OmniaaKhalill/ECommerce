using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class ProductToUpdateDto
    {
        public string name { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string image_link { get; set; }
        public int? CategoryId { get; set; }
        public List<Coulor> Colors { get; set; }
        public int NumOfProductInStock { get; set; }
    }
}
