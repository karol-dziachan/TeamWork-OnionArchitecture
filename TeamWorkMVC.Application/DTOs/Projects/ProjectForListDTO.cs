using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectForListDTO : IMapFrom<Project>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectForListDTO>()
            .ForMember(i => i.OwnerName, opt => opt.MapFrom(x => x.AppUser.Email));
    }
    
}