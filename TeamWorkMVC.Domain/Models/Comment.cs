using System.ComponentModel.DataAnnotations;

namespace TeamWorkMVC.Domain.Models;

public class Comment
{
    public int Id { get; set; }
   
    [Required]
    public DateTime DateTime { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    [Required]
    public int TaskId { get; set; }
    
    public virtual Task Task { get; set; }    
    
    public string? AppUserId { get; set; }
    
    public virtual AppUser AppUser { get; set; }
    
}