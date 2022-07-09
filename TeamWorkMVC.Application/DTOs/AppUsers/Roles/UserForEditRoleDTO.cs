using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.AppUsers;

public class UserForEditRoleDTO : IMapFrom<AppUser>
{
    public string Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AppUser, UserForEditRoleDTO>();
    }
}