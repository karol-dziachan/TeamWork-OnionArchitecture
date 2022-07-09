using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.Comments;

public class CommentForListDTO : IMapFrom<Comment>
{
    public int Id { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public string TaskName { get; set; }
    
    public string AuthorName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Comment, CommentForListDTO>()
            .ForMember(i => i.TaskName, opt => opt.MapFrom(t => t.Task.Name))
            .ForMember(i => i.AuthorName, opt => opt.MapFrom(t => t.AppUser.UserName));
        
    }
}