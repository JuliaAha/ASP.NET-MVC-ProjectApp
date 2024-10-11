using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectApp.Core;

namespace ProjectApp.Persistence;

public class TaskDb
{
    [Key] //om data ska vara nyckel
    public int Id { get; set; }

    [Required] //om data är ett krav (not null i databasen)
    [MaxLength(256)] //vilken maxlängd de kan vara
    public string Description { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime LastUpdated { get; set; }


    [Required] 
    public Status Status { get; set; }

    //FK and navigation property
    [ForeignKey("ProjectId")] 
    public ProjectDb ProjectDb { get; set; }

    public int ProjectId { get; set; } //vår främmande nyckel
}
