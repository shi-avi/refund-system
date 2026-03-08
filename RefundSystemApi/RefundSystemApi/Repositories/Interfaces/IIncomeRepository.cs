//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Repositories.Interfaces
//{
//    public interface IIncomeRepository
//    {
//        Task<List<Income>> GetCitizenIncomesByYearAsync(int citizenId, int year);
//        Task AddRangeAsync(List<Income> incomes);
//    }
//}
namespace RefundSystemApi.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId);
    }
}