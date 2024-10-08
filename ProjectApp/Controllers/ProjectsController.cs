using Microsoft.AspNetCore.Mvc;

namespace ProjectApp.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectService projectService;

    public ProjectsController(IProjectService projectService)
    {
        this.projectService = projectService;
    }
}