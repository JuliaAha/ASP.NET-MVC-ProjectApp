using AutoMapper;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core.Interfaces;
using Project = ProjectApp.Core.Project;
using Task = ProjectApp.Core.Task;


namespace ProjectApp.Persistence;

public class MySqlProjectPersistence : IProjectPersistence
{
    private ProjectDbContext _dbcontext;
    private readonly IMapper _mapper;

    public MySqlProjectPersistence(ProjectDbContext dbcontext, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }

    public List<Project> GetAllByUserName(string userName)
    {
        var projectDbs = _dbcontext.ProjectDbs
            .Where(p => p.UserName == userName)
            .ToList();

        List<Project> result = new List<Project>();
        foreach (ProjectDb pdb in projectDbs)
        {
            Project project = _mapper.Map<Project>(pdb);
            result.Add(project);
        }
        return result;
    }
    

    public Project GetById(int id, string userName)
    {
        ProjectDb projectDb = _dbcontext.ProjectDbs
            .Where(p => p.Id == id && p.UserName.Equals(userName))
            .Include(p => p.TaskDbs)
            .FirstOrDefault(); //null if not found
        
        if (projectDb == null) throw new Exception("Project not found");
        
        Project project = _mapper.Map<Project>(projectDb);
        foreach (TaskDb taskDb in projectDb.TaskDbs)
        {
            Task task = _mapper.Map<Task>(taskDb);
            project.AddTask(task);
        }
        return project;
    }

    public void Save(Project project)
    {
        throw new NotImplementedException();
    }
}