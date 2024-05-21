using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Entities;

namespace E_Commerce.APIs.DTO
{
    public class ReviewsDto
    {
      
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public string? UserId { get; set; }

        public int? ProductId { get; set; }

        public string? DisplayName { get; set; }

        public AppUser? User { get; set; }
        public Product? Product { get; set; }


    }
}
