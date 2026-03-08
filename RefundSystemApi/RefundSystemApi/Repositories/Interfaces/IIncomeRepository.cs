namespace RefundSystemApi.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId);
    }
}