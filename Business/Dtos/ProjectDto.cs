using Business.Helpers;

namespace Business.Dtos;

public class ProjectDto
{
    
    public string Name { get; set; } = null!;
    
    public string DateCreated { get; set; } = DateTime.Now.ToString("d");
    
    public string DateDue { get; set; }

    public bool IsCompleted { get; set; } = false;
    
}