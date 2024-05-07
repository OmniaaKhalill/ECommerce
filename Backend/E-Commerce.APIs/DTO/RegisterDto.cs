using System.ComponentModel.DataAnnotations;

namespace Talabat.Api.Dto
{
    public class RegisterDto
    {



        [Required]
        public String DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        [Required]
        public String PhoneNumber { get; set; }
    }
}
