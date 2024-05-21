using E_Commerce.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace E_Commerce.APIs.DTO
{
    public class CartItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quentity { get; set; }

        public int price {  get; set; }
        public color colors { get; set; }


    }
}
