using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class CategoriesDto
    {
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}
