//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Repositories.Interfaces
//{
//    public interface ICitizenRepository
//    {
//        Task<Citizen> GetByIdentityAsync(string identityNumber);
//        Task<Citizen> GetByIdAsync(int id);
//    }
//}

using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Repositories.Interfaces
{
    public interface ICitizenRepository
    {
        Task<Citizens?> GetByIdAsync(int id);

        Task<object?> GetCitizenByIdentityAsync(string identityCitizen);

        Task<Citizens> CreateCitizenAsync(Citizens citizen);
    }
}