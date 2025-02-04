using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key] [Required] public string Id { get; set; } = null!;
    
    [Column(TypeName="nvarchar(50)")]
    public string Name { get; set; } = null!;

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public DateTime DateDue { get; set; }
    
    public bool IsCompleted { get; set; }
    
    
    public string OwnerId { get; set; }
    
    public ProjectOwnerEntity Owner { get; set; } = null!;
    
    public ICollection<CustomersEntity> Customers = [];

    public ICollection<ServicesEntity> Services = [];
}