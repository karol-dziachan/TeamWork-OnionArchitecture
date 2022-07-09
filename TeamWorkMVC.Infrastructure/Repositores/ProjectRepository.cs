using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;
using TeamWorkMVC.Infrastructure.Abstract;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Infrastructure.Repositores;

public class ProjectRepository: BaseRepository, IProjectRepository
{
    public ProjectRepository(Context context) : base(context)
    {
    }


    public int AddItem(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
        return project.Id;
    }

    public IQueryable<Project> GetAllItems()
    {
        return _context.Projects;
    }

    public Project GetItemById(int id)
    {
        var project = _context.Projects.Include(u => u.AppUser).FirstOrDefault(i => i.Id == id);

        return project;
    }

    public int EditItem(Project model)
    {
        _context.Projects.Update(model);
        _context.SaveChanges();
        return model.Id;
    }

    public int DeleteItem(int id)
    {
        var project = _context.Projects.Find(id);
        
        if (project != null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        return project.Id;
    }
}