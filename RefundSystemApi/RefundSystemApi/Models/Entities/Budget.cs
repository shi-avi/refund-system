using System.ComponentModel.DataAnnotations.Schema;

namespace RefundSystemApi.Models.Entities
{
    [Table("Budget")]
    public class Budget
    {
        public int BudgetId { get; set; }

        public int? RequestId { get; set; } // nullable כי מסד מאפשר NULL

        public decimal AmountChange { get; set; }

        public decimal NewBudget { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property (לא חובה, אבל מומלץ)
        public RefundRequests Request { get; set; }
    }
}
