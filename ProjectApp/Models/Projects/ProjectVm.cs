using System.ComponentModel.DataAnnotations;
using ProjectApp.Core;

namespace ProjectApp.Models.Projects;

public class ProjectVm
{ 
    // Id:t ska skickas med i klienten, men inte listas i HTML-koden
    [ScaffoldColumn(false)] public int Id { get; set; }
    public string Title { get; set; }

    [Display(Name = "Created dae")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime CreatedDate { get; set; }

    public bool IsCompleted { get; set; }

    public static ProjectVm FromProject(Project project)
    {
        return new ProjectVm()
        {
            Id = project.Id,
            Title = project.Title,
            CreatedDate = project.CreatedDate,
            IsCompleted = project.IsCompleted()
        };
    }
}