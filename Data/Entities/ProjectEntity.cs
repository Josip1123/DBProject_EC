using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;


namespace Data.Entities;

[Table("Projects")]
public class ProjectEntity
{
    [Key] [Required] public string Id { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")] public string Name { get; set; } = null!;

    public string DateCreated { get; set; } = DateTime.Now.ToString("d");
    
    public string DateDue { get; set; }
    
    public bool IsCompleted { get; set; }
    
    [NotMapped] 
    public string Status
    {
        get
        {
            if (IsCompleted)
                return "Completed";

            DateTime dateDue; 
            var canParseDate = DateTime.TryParse(DateDue, out dateDue);
            
            if (!canParseDate)
                return "Unknown";
            
            
            return DateTime.Now > dateDue ? "Past Due" : "Ongoing";
        }
    }

    public ICollection<ProjectOwnerEntity> Owners { get; set; } = [];
    
    public ICollection<CustomersEntity> Customers { get; set; } = [];

    public ICollection<ServicesEntity> Services { get; set; } = [];

}