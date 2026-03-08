using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefundSystemApi.Models.Entities
{
    [Table("Incomes")]
    public class Incomes
    {
        [Key]
        public int IncomesId { get; set; }

        public int CitizenId { get; set; }

        [ForeignKey(nameof(CitizenId))]
        public Citizens Citizen { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        //[Range(1, 12)]
        public int Month { get; set; }

        public int Year { get; set; }
    }
}
