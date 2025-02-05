using Business.Helpers;

namespace Business.Dtos;

public class ProjectOwnerDto
{
    public string Id { get; set; } = $"PO - {NanoIdGenerator.GenerateId(5)}";
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
}