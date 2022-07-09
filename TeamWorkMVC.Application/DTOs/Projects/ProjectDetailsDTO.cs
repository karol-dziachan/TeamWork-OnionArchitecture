using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectDetailsDTO : IMapFrom<Project>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
   
    public string? Deadline { get; set; }
    
    public string OwnerName { get; set; }
    
    public ICollection<Task> TasksInProject { get; set;  }
    
    public ICollection<WorkerProject> WorkersInProjects { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectDetailsDTO>()
            .ForMember(o => o.OwnerName, opt => opt.MapFrom(i => i.AppUser.UserName))
            .ForMember(o => o.TasksInProject, opt => opt.MapFrom(i => i.Tasks))
            .ForMember(o => o.WorkersInProjects, opt => opt.MapFrom(i => i.WorkerProject));
    }
}