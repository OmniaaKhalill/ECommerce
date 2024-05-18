namespace E_Commerce.APIs.DTO
{
    public class UserToReturnDTO
    {
        public string? DisplayName { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }


        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
