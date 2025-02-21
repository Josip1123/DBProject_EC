using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class ProjectOwnerEntity
{
    [Key]
    [Column(TypeName="nvarchar(50)")]
    public required string Id { get; set; }
    
    [Column(TypeName="nvarchar(50)")] 
    public required string Name { get; set; } = null!;
    
    [Column(TypeName="nvarchar(150)")]
    public string Email { get; set; } = null!;


    public required string ProjectId { get; set; }
    
    [JsonIgnore]
    public ProjectEntity Project { get; set; } = null!;
    
    [NotMapped]
    [JsonPropertyName("projectName")]
    public string? ProjectName => Project.Name;


}