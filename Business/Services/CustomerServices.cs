using System.Diagnostics;
using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class CustomerServices(CustomersRepository customersRepository) : ICustomerServices
{
    public async Task CreateCustomerAsync(CustomersEntity customer)
    {
        try
        {
            await customersRepository.AddAsync(customer);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }

    public async Task<List<CustomersEntity>> GetAllAsync()
    {
        try
        {
            var projects = await customersRepository.GetAllAsync();
            return projects;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task<CustomersEntity> GetByIdAsync(string id)
    {
        try
        {
            var customer = await customersRepository.GetAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
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
                throw new Exception("Customer not found");
            }
            await customersRepository.DeleteAsync(entityToDelete);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task UpdateAsync(CustomerDto customer, string id)
    {
        try
        {
            var entityToUpdate = await GetByIdAsync(id);
            if (entityToUpdate == null)
            {
                throw new Exception("Customer not found");
            }
            entityToUpdate.Name = customer.Name;
            entityToUpdate.Email = customer.Email;
            await customersRepository.UpdateAsync(entityToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}