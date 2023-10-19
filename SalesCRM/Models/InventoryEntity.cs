using System.ComponentModel;

namespace SalesCRM.Models
{
    public class InventoryEntity
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int? Quantity { get; set; }
        [DisplayName("Date Received")]
        public DateTime? DateReceived { get; set; }
        [DisplayName("Date Shipped")]
        public DateTime? DateShipped { get; set; }
    }
}
