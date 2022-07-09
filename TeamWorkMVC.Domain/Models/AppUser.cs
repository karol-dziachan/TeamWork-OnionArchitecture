using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using Microsoft.AspNetCore.Identity;

namespace TeamWorkMVC.Domain.Models;

public class AppUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public string? TelephoneNumber { get; set; }
    
    public ICollection<Address> Address { get; set; }
    
    public ICollection<Project> Projects { get; set; }
    
    public ICollection<WorkerProject> WorkerProject { get; set; }
    
    public ICollection<WorkerTask> WorkerTask { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
}