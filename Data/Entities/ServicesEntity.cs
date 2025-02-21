using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class ServicesEntity
{
        [Key] [Required] public string Id { get; set; } 
        
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; } = null!;
        
        [Column(TypeName="nvarchar(150)")]
        public string Description { get; set; } = null!;
        
        public decimal Price { get; set; }
        
        
        public required string ProjectId { get; set; }
    
        [JsonIgnore]
        public ProjectEntity Project { get; set; } = null!;
        
        [NotMapped]
        [JsonPropertyName("projectName")]
        public string? ProjectName => Project.Name;
}
