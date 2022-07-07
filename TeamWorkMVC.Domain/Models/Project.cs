using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamWorkMVC.Domain.Models;

public class Project
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
   
    public string? Deadline { get; set; }
    
    public string? AppUserId { get; set; } // Owner
    
    public virtual AppUser AppUser { get; set; }
    
    public ICollection<WorkerProject> WorkerProject { get; set; }
    
    public virtual ICollection<Task> Tasks { get; set; }
}