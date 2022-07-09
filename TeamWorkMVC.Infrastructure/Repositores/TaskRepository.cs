using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Infrastructure.Abstract;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Infrastructure.Repositores;

public class TaskRepository : BaseRepository, ITaskRepository
{
    public TaskRepository(Context context) : base(context)
    {
        
    }
    public int AddItem(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task.Id;
    }

    public IQueryable<Task> GetAllItems()
    {
        return _context.Tasks;
    }

    public Task GetItemById(int id)
    {
        var task = _context.Tasks
            .Include(t => t.Project)
            .FirstOrDefault(i => i.Id == id);

        return task;
    }

    public Task GetItemByProjectId(int id)
    {
        var task = _context.Tasks.FirstOrDefault(i => i.ProjectId == id);

        return task;
    }

    public int EditItem(Task model)
    {
        _context.Tasks.Update(model);
        _context.SaveChanges();
        return model.Id;
    }

    public int DeleteItem(int id)
    {
        var task = _context.Tasks.Find(id);
        
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        return task.Id;
    }

  
}