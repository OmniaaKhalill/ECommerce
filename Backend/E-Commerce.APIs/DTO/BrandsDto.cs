using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class BrandsDto
    {
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}
