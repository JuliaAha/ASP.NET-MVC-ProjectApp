using ProjectApp.Core.Interfaces;
using ProjectApp.Core.Interfaces.Interfaces;

namespace ProjectApp.Core;

public class ProjectService : IProjectService
{
    private readonly IProjectPersistence _projectPersistence;

    public ProjectService(IProjectPersistence projectPersistence)
    {
        _projectPersistence = projectPersistence;
    }

    public List<Project> GetAllByUserName(string userName)
    {
        List<Project> projects = _projectPersistence.GetAllByUserName(userName);
        return projects;
    }

    public Project GetById(int id, string userName)
    {
        throw new NotImplementedException();
    }

    public void Add(string userName, string Title)
    {
        throw new NotImplementedException();
    }
}