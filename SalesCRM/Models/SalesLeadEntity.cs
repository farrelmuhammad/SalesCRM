using System.ComponentModel;

namespace SalesCRM.Models
{
    public class SalesLeadEntity
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Source { get; set; }
    }
}
