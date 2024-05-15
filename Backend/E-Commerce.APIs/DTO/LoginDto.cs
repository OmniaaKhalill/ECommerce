using System.ComponentModel.DataAnnotations;

namespace E_Commerce.APIs.DTO
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }


    }
}
