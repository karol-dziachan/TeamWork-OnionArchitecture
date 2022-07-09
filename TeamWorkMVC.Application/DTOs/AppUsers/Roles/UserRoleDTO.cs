using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.AppUsers;

public class UserRoleDTO : IMapFrom<AppUser>
{
    public string UserId { get; set; }
    public string RoleId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AppUser, UserRoleDTO>()
            .ForMember(i => i.UserId, opt => opt.MapFrom(x =>x.Id));
    }
}