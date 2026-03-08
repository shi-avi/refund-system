//using RefundSystemApi.Models.DTO;
//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Services.Interfaces
//{
//    public interface ICitizenService
//    {
//        Task<Citizen> GetByIdentityAsync(string identityNumber);
//        Task<CitizenDetailsDto> GetCitizenDetailsAsync(string identity);
//    }
//}
using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Services.Interfaces
{
    public interface ICitizenService
    {
        Task<Citizens?> GetByIdAsync(int id);

        Task<object?> GetCitizenByIdentityAsync(string identityCitizen);

        Task<Citizens> CreateCitizenAsync(Citizens citizen);
    }
}