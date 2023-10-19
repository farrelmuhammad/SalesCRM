using SalesCRM.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SalesCRM.Models
{
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }
        [Required]
        [EnumDataType(typeof(StatusTask))]
        public StatusTask? Status { get; set; }

        public int? CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
    }
}
