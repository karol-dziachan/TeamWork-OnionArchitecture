using AutoMapper;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.Mapping;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Application.DTOs.Tasks;

public class TaskCreateDTO : IMapFrom<Task>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Deadline { get; set; }
    public int ProjectId { get; set; }
    public bool State { get; set; }
    
    public IQueryable<ProjectForSelectDTO> AvailableProjects { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TaskCreateDTO, Task>();
    }
}