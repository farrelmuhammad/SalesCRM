namespace SalesCRM.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public decimal? Price { get; set; }
    }
}
