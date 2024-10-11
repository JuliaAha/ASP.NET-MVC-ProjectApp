using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Persistence;

public class ProjectDb
{
    [Key] //om data ska vara nyckel
    public int Id { get; set; }
    
    [Required] //om data är ett krav (not null i databasen)
    [MaxLength(128)] //vilken maxlängd de kan vara
    public string Title { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }
    
    //navigation property
    public List<TaskDb> TaskDbs { get; set; } = new List<TaskDb>();
}