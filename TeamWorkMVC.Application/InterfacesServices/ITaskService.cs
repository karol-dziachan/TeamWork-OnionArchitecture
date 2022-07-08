using TeamWorkMVC.Application.DTOs.Tasks;

namespace TeamWorkMVC.Application.InterfacesServices;

public interface ITaskService
{
    int AddTask(TaskCreateDTO model);
    IQueryable<TaskForListDTO> GetAllTasksForList();
    TaskDetailsDTO GetTaskById(int id);
    TaskDetailsDTO GetTaskByProjectId(int id);
    TaskUpdateDTO GetTaskForEdit(int id);
    int EditTask(TaskUpdateDTO model);
    int DeleteTask(int id);
}