using Business.Helpers;

namespace Business.Dtos;

public class ServiceDto
{
    
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public string ProjectId { get; set; }
    
    
}