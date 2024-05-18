namespace E_Commerce.APIs.DTO
{
    public class ReviewsToReturnDto
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public string? UserId { get; set; }

        public int? ProductId { get; set; }

        public string UserName { get; set; }
    }
}
