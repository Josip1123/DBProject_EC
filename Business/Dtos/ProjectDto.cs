using Business.Helpers;

namespace Business.Dtos;

public class ProjectDto
{
    public string Id = $"P - {NanoIdGenerator.GenerateId(5)}";

    public string Name { get; set; } = null!;
    
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    
    public DateTime DateDue { get; set; }

    public bool IsCompleted { get; set; } = false;
}