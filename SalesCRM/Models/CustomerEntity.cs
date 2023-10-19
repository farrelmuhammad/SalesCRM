using SalesCRM.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesCRM.Models
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set;}
        [Required]
        public string? Mobile { get; set; }
        public string? Notes { get; set; }
        [DisplayName("Registration Date")]
        public DateTime? RegistrationDate { get; set; }
        [EnumDataType(typeof(CustomerStatus))]
        public CustomerStatus Status { get; set; }
    }
}
