using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public class IOwnerServices
{
    public interface IServices
    {
        Task CreateProjectAsync(ProjectOwnerEntity project);
        Task<List<ProjectOwnerEntity>> GetAllAsync();
        Task<ProjectOwnerEntity> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(ProjectOwnerDto project, string id);
    }
}