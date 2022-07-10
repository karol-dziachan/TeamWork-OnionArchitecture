using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Domain.InterfacesRepository;

public interface IProjectRepository
{
    int AddItem(Project task);
    
    IQueryable<Project> GetAllItems(); 
    
    Project GetItemById(int id);
    
    int EditItem(Project task);
    
    int DeleteItem(int id);
}