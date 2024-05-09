using E_Commerce.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.APIs.DTO
{
    public class SellerToCreateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IDImgUrl { get; set; }
        public bool IsAccepted { get; set; }
        public List<Product>? ProductList { get; set; }
        public int? PageId { get; set; }
        public string Page { get; set; }
    }
}
