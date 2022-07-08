using System.ComponentModel;
using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Application.DTOs.Tasks;

public class TaskDetailsDTO : IMapFrom<Task>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string? Deadline { get; set; }

    public string State { get; set; }
    
    [DisplayName("Project name")]
    public Project Project { get; set; }
    
    /*[DisplayName("Workers in task")]
    public ICollection<WorkerTask> WorkerTask { get; set; }
    
    [DisplayName("Comments in task")]
    public virtual  ICollection<Comment> Comments { get; set; }*/

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Task, TaskDetailsDTO>()
            .ForMember(d => d.Project, opt => opt.MapFrom(s => s.Project))

            .ForMember(d => d.State, opt => opt.MapFrom(s => (s.State == true ? "active" : "done")));
    }
}