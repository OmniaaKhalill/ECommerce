using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class CategoriesDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}
