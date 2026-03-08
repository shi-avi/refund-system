//using RefundSystemApi.Models.DTO;
//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Services.Interfaces
//{
//    public interface IIncomeService
//    {
//        Task<List<Income>> GetCitizenIncomesByYearAsync(int citizenId, int year);
//        Task AddRangeAsync(List<Income> incomes);
//    }
//}
namespace RefundSystemApi.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId);
    }
}