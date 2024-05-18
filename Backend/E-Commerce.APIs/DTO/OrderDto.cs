using E_Commerce.Core.Entities.Oreder_Agrigate;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class OrderDto
    {
        [Required]
        public  string buyerEmail {  get; set; }
        [Required]

        public string CartId { get; set; }
        

        

        public AddressDto shippingAddress { get; set; }
    }
}
