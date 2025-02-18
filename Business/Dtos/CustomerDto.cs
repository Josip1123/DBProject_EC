using Business.Helpers;

namespace Business.Dtos;

public class CustomerDto
{
    public string Id = $"C - {NanoIdGenerator.GenerateId(5)}";

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public string ProjectId { get; set; }
}