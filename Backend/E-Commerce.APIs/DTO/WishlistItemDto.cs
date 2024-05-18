using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class WishlistItemDto
    {
        [Required]
        public int Id { get; set; }
    }
}
