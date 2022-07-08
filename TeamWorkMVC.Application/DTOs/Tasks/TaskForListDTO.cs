using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Application.DTOs.Tasks;

public class TaskForListDTO : IMapFrom<Task>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string ProjectName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Task, TaskForListDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.ProjectName, opt => opt.MapFrom(s => s.Project.Name));
    }
    
}