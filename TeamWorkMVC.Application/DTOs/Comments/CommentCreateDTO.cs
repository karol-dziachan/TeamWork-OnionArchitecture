using AutoMapper;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.DTOs.Comments;

public class CommentCreateDTO : IMapFrom<Comment>
{
    public int Id { get; set; }
   
    public DateTime DateTime { get; set; }
    
    public string Content { get; set; }
    
    public int TaskId { get; set; }
    
    public string? AppUserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CommentCreateDTO, Comment>();
    }
}