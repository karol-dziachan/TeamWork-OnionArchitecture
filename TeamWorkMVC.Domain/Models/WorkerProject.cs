namespace TeamWorkMVC.Domain.Models;

public class WorkerProject
{
    public string AppUserId { get; set; }
    public int ProjectId { get; set; }
    public AppUser AppUser { get; set; }
    public Project Project { get; set; }
}