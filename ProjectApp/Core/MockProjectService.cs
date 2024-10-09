using ProjectApp.Core.Interfaces.Interfaces;

namespace ProjectApp.Core;

public class MockProjectService : IProjectService
{
    public List<Project> GetAllByUserName(string userName)
    {
        return _projects;
    }
    
    public Project GetById(int id)
    {
       return _projects.Find(p => p.Id == id); 
    }

    public void Add(string userName, string Title)
    {
        throw new NotImplementedException("MockProjectService.Add");
    }
    private static readonly List<Project> _projects = new();
    
    //C# style static initializer
    static MockProjectService()
    {
        Project p1 = new Project(1,"Learn ASP.NET with MVC", DateTime.Now, "Julia");
        Project p2 = new Project(2,"Prepare for your bachelor Thesis", DateTime.Now, "Emma");
        p2.AddTask(new Core.Task(1,"Find an interesting topic and company"));
        p2.AddTask(new Core.Task(1, "Kill Emma"));
        _projects.Add(p1);
        _projects.Add(p1);
    }
}