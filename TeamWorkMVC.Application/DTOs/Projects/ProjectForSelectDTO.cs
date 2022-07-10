using AutoMapper;
using TeamWorkMVC.Application.DTOs.Tasks;
using TeamWorkMVC.Application.Mapping;

namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectForSelectDTO : IMapFrom<ProjectForListDTO>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectForListDTO, ProjectForSelectDTO>();
    }
}