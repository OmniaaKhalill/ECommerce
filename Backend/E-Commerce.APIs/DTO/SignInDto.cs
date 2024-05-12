using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class SignInDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
