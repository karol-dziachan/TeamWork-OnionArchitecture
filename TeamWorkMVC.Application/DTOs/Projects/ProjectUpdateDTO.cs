using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectUpdateDTO : IMapFrom<Project>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
   
    public string? Deadline { get; set; }
    
    public string? AppUserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectUpdateDTO, Project>().ReverseMap();
    }
}