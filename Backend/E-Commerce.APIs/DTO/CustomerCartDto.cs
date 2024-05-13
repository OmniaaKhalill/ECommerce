using E_Commerce.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class CustomerCartDto
    {

        [Required]
        public string Id { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public List<CartItemDto> Items { get; set; }



    }
}
