namespace TeamWorkMVC.Domain.Models;

public class WorkerTask
{
    public string AppUserId { get; set; }
    public int TaskId { get; set; }
    public AppUser AppUser { get; set; }
    public Task Task { get; set; }
}