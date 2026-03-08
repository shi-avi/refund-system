using RefundSystemApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefundSystemApi.Models.Entities
{
    [Table("RefundRequests")]
    public class RefundRequests
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int CitizenId { get; set; }

        [ForeignKey(nameof(CitizenId))]
        public Citizens Citizen { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RefundAmount { get; set; }

        public int Year { get; set; }
   
        public String Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
