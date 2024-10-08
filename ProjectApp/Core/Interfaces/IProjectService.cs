namespace ProjectApp.Core.Interfaces.Interfaces;

public interface IProjectService
{
    List<Project> GetAllByUserName(string userName);
    
    Project GetById(int id);
    
    void Add(string userName, string Title);
    
}