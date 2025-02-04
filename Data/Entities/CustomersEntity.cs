using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomersEntity
{
    [Key]
    [Required]
    public string Id { get; set; }
    
    [Column(TypeName="nvarchar(50)")]
    public string Name { get; set; } = null!;
    
    [Column(TypeName="nvarchar(150)")]
    public string Email { get; set; } = null!;

    public ICollection<ProjectEntity> Projects = [];

    public ICollection<ServicesEntity> Services = [];
}