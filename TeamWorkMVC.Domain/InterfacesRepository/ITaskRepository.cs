using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Domain.InterfacesRepository;

public interface ITaskRepository
{
    int AddItem(Task task);
    
    IQueryable<Task> GetAllItems(); 
    
    Task GetItemById(int id);
    
    Task GetItemByProjectId(int id);
    
    int EditItem(Task task);
    
    int DeleteItem(int id);
}