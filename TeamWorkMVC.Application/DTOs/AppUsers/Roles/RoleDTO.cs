using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamWorkMVC.Application.Mapping;

namespace TeamWorkMVC.Application.DTOs.AppUsers;

public class RoleDTO : IMapFrom<IdentityRole>
{
    private string RoleId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RoleDTO, IdentityRole>();
    }
}