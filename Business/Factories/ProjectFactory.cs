using Business.Dtos;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectDto dto)
    {
        return new ProjectEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            DateCreated = dto.DateCreated,
            DateDue = dto.DateDue,
            IsCompleted = dto.IsCompleted
        };
    }
    
    public static ProjectOwnerEntity Create(ProjectOwnerDto dto)
    {
        return new ProjectOwnerEntity()
        {
            Name = dto.Name,
            Email = dto.Email
        };
    }
    public static CustomersEntity Create(CustomerDto dto)
    {
        return new CustomersEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email
        };
    }
    
    public static ServicesEntity Create(ServiceDto dto)
    {
        return new ServicesEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
        };
    }
}