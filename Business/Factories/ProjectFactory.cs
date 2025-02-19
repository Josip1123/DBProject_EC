using Business.Dtos;
using Business.Helpers;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectDto dto)
    {
        return new ProjectEntity()
        {
            Id = $"P - {NanoIdGenerator.GenerateId(5)}",
            Name = dto.Name,
            DateDue = dto.DateDue,
            IsCompleted = dto.IsCompleted,
        };
    }
    
    public static ProjectOwnerEntity Create(ProjectOwnerDto dto)
    {
        return new ProjectOwnerEntity()
        {
            Id = $"PO - {NanoIdGenerator.GenerateId(5)}",
            Name = dto.Name,
            Email = dto.Email,
            ProjectId = dto.ProjectId
        };
    }
    public static CustomersEntity Create(CustomerDto dto)
    {
        return new CustomersEntity()
        {
            Id = $"C - {NanoIdGenerator.GenerateId(5)}",
            Name = dto.Name,
            Email = dto.Email,
            ProjectId = dto.ProjectId
        };
    }
    
    public static ServicesEntity Create(ServiceDto dto)
    {
        return new ServicesEntity()
        {
            Id = $"S - {NanoIdGenerator.GenerateId(5)}",
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ProjectId = dto.ProjectId
        };
    }
    
}