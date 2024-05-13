using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class CartItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ImageUrel { get; set; }
        [Required]
        [Range(0, double.MaxValue,ErrorMessage ="price must be more than zero")]
        public decimal price { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string brand { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Quentity { get; set; }


    }
}
