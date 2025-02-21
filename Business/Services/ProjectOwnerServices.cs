using System.Diagnostics;
using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ProjectOwnerServices(ProjectOwnerRepository ownerRepository) : IOwnerServices
{
    public async Task CreateProjectOwnerAsync(ProjectOwnerEntity owner)
    {
        try
        {
            await ownerRepository.AddAsync(owner);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }

    public async Task<List<ProjectOwnerEntity>> GetAllAsync()
    {
        try
        {
            var owners = await ownerRepository.GetAllAsync();
            return owners;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task<ProjectOwnerEntity> GetByIdAsync(string id)
    {
        try
        {
            var owner = await ownerRepository.GetAsync(x => x.Id == id);
            if (owner == null)
            {
                throw new Exception("Project Owner not found");
            }
            return owner;
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
                throw new Exception("Project Owner not found");
            }
            await ownerRepository.DeleteAsync(entityToDelete);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task UpdateAsync(ProjectOwnerDto owner, string id)
    {
        try
        {
            var entityToUpdate = await GetByIdAsync(id);
            if (entityToUpdate == null)
            {
                throw new Exception("Project Owner not found");
            }
            entityToUpdate.Name = owner.Name;
            entityToUpdate.Email = owner.Email;
            await ownerRepository.UpdateAsync(entityToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}