namespace E_Commerce.APIs.DTO
{
    public class ProductPaginationDto
    {
   
    
        public IEnumerable<ProductSellerDto> Items { get; set; }=new List<ProductSellerDto>();
        public int TotalCount { get; set; }
    
    }
}
