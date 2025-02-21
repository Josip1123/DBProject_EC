using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public class ICustomerServices
{
    public interface IServices
    {
        Task CreateProjectAsync(CustomersEntity project);
        Task<List<CustomersEntity>> GetAllAsync();
        Task<CustomersEntity> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(CustomerDto project, string id);
    }
}