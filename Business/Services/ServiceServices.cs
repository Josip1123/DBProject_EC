using System.Diagnostics;
using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ServiceServices(ServicesRepository servicesRepository) : IServiceServices
{
    public async Task CreateServiceAsync(ServicesEntity service)
    {
        try
        {
            await servicesRepository.AddAsync(service);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }

    public async Task<List<ServicesEntity>> GetAllAsync()
    {
        try
        {
            var services = await servicesRepository.GetAllAsync();
            return services;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task<ServicesEntity> GetByIdAsync(string id)
    {
        try
        {
            var service = await servicesRepository.GetAsync(x => x.Id == id);
            if (service == null)
            {
                throw new Exception("Service not found");
            }
            return service;
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
                throw new Exception("Service not found");
            }
            await servicesRepository.DeleteAsync(entityToDelete);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task UpdateAsync(ServiceDto service, string id)
    {
        try
        {
            var entityToUpdate = await GetByIdAsync(id);
            if (entityToUpdate == null)
            {
                throw new Exception("Service not found");
            }
            entityToUpdate.Name = service.Name;
            entityToUpdate.Description = service.Description;
            entityToUpdate.Price = service.Price;
            await servicesRepository.UpdateAsync(entityToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}