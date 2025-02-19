using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public interface IServices
{
    Task CreateProjectAsync(ProjectEntity project);
    Task<List<ProjectEntity>> GetAllAsync();
    Task<ProjectEntity> GetByIdAsync(string id);
    Task<ProjectEntity> GetByNameAsync(string name);
    Task DeleteAsync(string id);
    Task UpdateAsync(ProjectDto project, string id);
}