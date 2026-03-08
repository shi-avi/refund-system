namespace RefundSystemApi.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId);
    }
}