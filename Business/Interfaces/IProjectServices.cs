using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public interface IProjectServices
{
    Task CreateProjectAsync(ProjectEntity project);
    Task<List<ProjectEntity>> GetAllAsync();
    Task<ProjectEntity> GetByIdAsync(string id);
    Task DeleteAsync(string id);
    Task UpdateAsync(ProjectDto project, string id);
}