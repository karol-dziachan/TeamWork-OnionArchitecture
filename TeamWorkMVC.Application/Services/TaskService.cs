using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeamWorkMVC.Application.DTOs.Tasks;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Domain.InterfacesRepository;
using Task = TeamWorkMVC.Domain.Models.Task;

namespace TeamWorkMVC.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository; 
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public int AddTask(TaskCreateDTO model)
    {
        var task = _mapper.Map<Task>(model);
        var id = _taskRepository.AddItem(task);

        return id;
    }

    public IQueryable<TaskForListDTO> GetAllTasksForList()
    {
        var tasks = _taskRepository.GetAllItems();
        var tasksDTO = tasks.ProjectTo<TaskForListDTO>(_mapper.ConfigurationProvider);
        
        return tasksDTO;
    }

    public TaskDetailsDTO GetTaskByProjectId(int id)
    {
        var task = _taskRepository.GetItemByProjectId(id);
        var taskDTO = _mapper.Map<TaskDetailsDTO>(task);

        return taskDTO;
    }

    public TaskDetailsDTO GetTaskById(int id)
    {
        var task = _taskRepository.GetItemById(id);
        var taskDTO = _mapper.Map<TaskDetailsDTO>(task);

        return taskDTO;
    }

    public TaskUpdateDTO GetTaskForEdit(int id)
    {
        var task = _taskRepository.GetItemById(id);
        var taskDTO = _mapper.Map<TaskUpdateDTO>(task);

        return taskDTO;
    }

    public int EditTask(TaskUpdateDTO model)
    {
        var task = _mapper.Map<Task>(model);
        var taskID = _taskRepository.EditItem(task);

        return taskID;
    }

    public int DeleteTask(int id)
    {
        var taskId = _taskRepository.DeleteItem(id);

        return taskId;
    }
}