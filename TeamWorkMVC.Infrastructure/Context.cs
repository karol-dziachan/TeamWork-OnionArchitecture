using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Domain.Models;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Infrastructure;
public class Context : IdentityDbContext
{
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<AppUser> AppUsers { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<WorkerProject> WorkerProject { get; set; }
    public DbSet<WorkerTask> WorkerTask { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Project>()
            .HasOne(p => p.AppUser)
            .WithMany(a => a.Projects)
            .HasForeignKey(p => p.AppUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasMany<Task>(s => s.Tasks)
            .WithOne(x => x.Project)
            .HasForeignKey(y => y.ProjectId);

        
        builder.Entity<WorkerProject>()
            .HasKey(it => new {it.AppUserId, it.ProjectId});

        builder.Entity<WorkerProject>()
            .HasOne<AppUser>(it => it.AppUser)
            .WithMany(i => i.WorkerProject)
            .HasForeignKey(it => it.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);      
        
        builder.Entity<WorkerProject>()
            .HasOne<Project>(it => it.Project)
            .WithMany(i => i.WorkerProject)
            .HasForeignKey(it => it.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<WorkerTask>()
            .HasKey(it => new {it.AppUserId, it.TaskId});

        builder.Entity<WorkerTask>()
            .HasOne<AppUser>(it => it.AppUser)
            .WithMany(i => i.WorkerTask)
            .HasForeignKey(it => it.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);     

        builder.Entity<WorkerTask>()
            .HasOne<Task>(it => it.Task)
            .WithMany(i => i.WorkerTask)
            .HasForeignKey(it => it.TaskId)
            .OnDelete(DeleteBehavior.Restrict);


    }
    
}