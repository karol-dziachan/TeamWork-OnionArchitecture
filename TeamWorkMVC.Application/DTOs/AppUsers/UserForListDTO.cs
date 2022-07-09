using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.AppUsers;

public class UserForListDTO : IMapFrom<AppUser>
{
    public string Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? TelephoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AppUser, UserForListDTO>();
    }
}