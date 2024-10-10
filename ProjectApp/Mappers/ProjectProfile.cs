using AutoMapper;
using ProjectApp.Persistence;
using ProjectApp.Core;

namespace ProjectApp.Mappers;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDb, Project>().ReverseMap();
    }
}