using Business.Helpers;

namespace Business.Dtos;

public class ServiceDto
{
    public string Id { get; set; } = $"S - {NanoIdGenerator.GenerateId(5)}";
    
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
}