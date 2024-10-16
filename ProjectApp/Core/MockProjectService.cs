using ProjectApp.Core.Interfaces.Interfaces;

namespace ProjectApp.Core;

public class MockProjectService : IProjectService
{
    public List<Project> GetAllByUserName(string userName)
    {
        return _projects;
    }
    
    public Project GetById(int id, string userName)
    {
       return _projects.Find(p => p.Id == id && p.UserName == userName); 
       
    }

    public void Add(string userName, string Title)
    {
        throw new NotImplementedException("MockProjectService.Add");
    }
    private static readonly List<Project> _projects = new();
    
    //C# style static initializer
    static MockProjectService()
    {
        Project p1 = new Project(1,"Learn ASP.NET with MVC", DateTime.Now, "julg@kth.se");
        Project p2 = new Project(2,"Prepare for your bachelor Thesis", DateTime.Now, "julg@kth.se");
        p2.AddTask(new Core.Task(1,"Fix my code"));
        p2.AddTask(new Core.Task(1, "Kill Emma"));
        _projects.Add(p1);
        _projects.Add(p2);
    }
}