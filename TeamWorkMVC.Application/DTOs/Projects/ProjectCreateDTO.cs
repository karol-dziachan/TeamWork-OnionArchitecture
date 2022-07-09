using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectCreateDTO : IMapFrom<Project>
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
   
    public string? Deadline { get; set; }
    
    public string? AppUserId { get; set; } // Owner

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectCreateDTO, Project>();
    }
}