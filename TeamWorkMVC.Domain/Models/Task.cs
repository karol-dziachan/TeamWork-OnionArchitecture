using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    
    [ForeignKey("TaskId")]    
    public Project Project { get; set; }
    
    [DefaultValue("false")]
    public bool State { get; set; }
    
    public ICollection<WorkerTask> WorkerTask { get; set; }
    
    public  ICollection<Comment> Comments { get; set; }
}