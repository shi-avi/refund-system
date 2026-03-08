namespace RefundSystemApi.Models.Entities
{
    public class ProcessRefundResult
    {
        public decimal RefundAmount { get; set; }

        public decimal BudgetBefore { get; set; }
        public decimal BudgetAfter { get; set; }
    }
}
