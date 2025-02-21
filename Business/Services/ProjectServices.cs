using System.Diagnostics;
using Business.Dtos;
using Business.Factories;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;


public class ProjectServices(ProjectsRepository projectsRepository) : IProjectServices
{
    public async Task CreateProjectAsync(ProjectEntity project)
    {
        try
        {
            await projectsRepository.AddAsync(project);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }

    public async Task<List<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var projects = await projectsRepository.GetAllAsync();
            return projects;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task<ProjectEntity> GetByIdAsync(string id)
    {
        try
        {
            var project = await projectsRepository.GetAsync(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            return project;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
    
  

    public async Task DeleteAsync(string id)
    {
        try
        {
            var entityToDelete = await GetByIdAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception("Project not found");
            }
            await projectsRepository.DeleteAsync(entityToDelete);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task UpdateAsync(ProjectDto project, string id)
    {
        try
        {
                var entityToUpdate = await GetByIdAsync(id);
                if (entityToUpdate == null)
                {
                    throw new Exception("Project not found");
                }
                entityToUpdate.Name = project.Name;
                entityToUpdate.DateDue = project.DateDue;
                entityToUpdate.IsCompleted = project.IsCompleted;
                await projectsRepository.UpdateAsync(entityToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}