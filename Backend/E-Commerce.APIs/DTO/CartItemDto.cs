using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class CartItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Quentity { get; set; }


    }
}
