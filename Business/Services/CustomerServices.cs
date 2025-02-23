using System.Diagnostics;
using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class CustomerServices(CustomersRepository customersRepository) : ICustomerServices
{
    public async Task CreateCustomerAsync(CustomersEntity customer)
    {
        await customersRepository.BeginTransactionAsync();
        
        try
        {
            await customersRepository.AddAsync(customer);
            await customersRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await customersRepository.RollbackAsync();
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
        await customersRepository.BeginTransactionAsync();
        try
        {
            var entityToDelete = await GetByIdAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception("Customer not found");
            }
            await customersRepository.DeleteAsync(entityToDelete);
            await customersRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await customersRepository.RollbackAsync();
            throw;
        }
        
    }

    public async Task UpdateAsync(CustomerDto customer, string id)
    {
        await customersRepository.BeginTransactionAsync();
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
            await customersRepository.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await customersRepository.RollbackAsync();
            throw;
        }
        
    }
}