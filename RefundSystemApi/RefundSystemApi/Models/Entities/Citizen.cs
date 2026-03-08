using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefundSystemApi.Models.Entities
{
    [Table("Citizens")]
    public class Citizens
    {
        [Key]
        public int CitizenId { get; set; }

        [Required]
        [StringLength(9)]
        public string IdentityCitizen { get; set; }  // תעודת זהות

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        // קשרים
        //public ICollection<Incomes> Incomes { get; set; }
        //public ICollection<RefundRequests> RefundRequests { get; set; }

    }
}
