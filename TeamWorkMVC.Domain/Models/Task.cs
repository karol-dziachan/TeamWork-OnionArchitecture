using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamWorkMVC.Domain.Models;

public class Task
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    public string? Deadline { get; set; }
    
    public int ProjectId { get; set; }
    
    [DefaultValue("false")]
    public bool State { get; set; }
    
    public virtual Project Project { get; set; }
    
    public ICollection<WorkerTask> WorkerTask { get; set; }
    
    public virtual  ICollection<Comment> Comments { get; set; }
}