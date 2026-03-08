using System.ComponentModel.DataAnnotations;

namespace RefundSystemApi.Models.DTO
{
    public class CreateRefundRequestDto
    {
        public int CitizenId { get; set; }

        public int Year { get; set; }


        public List<IncomeDto> Incomes { get; set; }
    }

    public class IncomeDto
    {
        public int Month { get; set; }

        public decimal Amount { get; set; }
    }
}
