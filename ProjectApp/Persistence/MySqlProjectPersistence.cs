using AutoMapper;
using Microsoft.Build.Evaluation;
using ProjectApp.Core.Interfaces;
using Project = ProjectApp.Core.Project;

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
    

    public Core.Project GetById(int id, string userName)
    {
        throw new NotImplementedException();
    }

    public void Save(Core.Project project)
    {
        throw new NotImplementedException();
    }
}