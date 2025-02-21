using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public class IServiceServices
{
    public interface IServices
    {
        Task CreateProjectAsync(ServicesEntity project);
        Task<List<ServicesEntity>> GetAllAsync();
        Task<ServicesEntity> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(ServiceDto project, string id);
    }
}