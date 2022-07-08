namespace TeamWorkMVC.Application.DTOs.Projects;

public class ProjectForListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Deadline { get; set; }
    public string OwnerName { get; set; }
}