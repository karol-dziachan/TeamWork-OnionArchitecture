using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.AppUsers;

public class UserUpdateDTO : IMapFrom<AppUser>
{
    public string Id { get; set; }
       
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? TelephoneNumber { get; set; }
    
    public string? Apartment { get; set; }
   
    public string Building { get; set; }
   
    public string Street { get; set; }
   
    public string City { get; set; }
   
    public string ZipCode { get; set; }
   
    public string Country { get; set; }

    public void Mapping(Profile profile)
    {

        profile.CreateMap<UserUpdateDTO, AppUser>().ReverseMap()
            .ForMember(i => i.Apartment, opt => opt.MapFrom(x => x.Address.Apartment))
            .ForMember(i => i.Building, opt => opt.MapFrom(x => x.Address.Building))
            .ForMember(i => i.Street, opt => opt.MapFrom(x => x.Address.Street))
            .ForMember(i => i.City, opt => opt.MapFrom(x => x.Address.City))
            .ForMember(i => i.ZipCode, opt => opt.MapFrom(x => x.Address.ZipCode))
            .ForMember(i => i.Country, opt => opt.MapFrom(x => x.Address.Country));
    }
}