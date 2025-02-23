using System.Diagnostics;
using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;


public class ProjectServices(ProjectsRepository projectsRepository) : IProjectServices
{
    public async Task CreateProjectAsync(ProjectEntity project)
    {
        await projectsRepository.BeginTransactionAsync();
        
        try
        {
            await projectsRepository.AddAsync(project);
            await projectsRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await projectsRepository.RollbackAsync();
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
        await projectsRepository.BeginTransactionAsync();
        
        try
        {
            var entityToDelete = await GetByIdAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception("Project not found");
            }

            
            await projectsRepository.DeleteAsync(entityToDelete);
            
            await projectsRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await projectsRepository.RollbackAsync();
            throw;
        }
        
    }

    public async Task UpdateAsync(ProjectDto project, string id)
    {
        await projectsRepository.BeginTransactionAsync();
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
                await projectsRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await projectsRepository.RollbackAsync();
            throw;
        }
        
    }
}