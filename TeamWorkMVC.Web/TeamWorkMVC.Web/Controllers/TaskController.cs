using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.DTOs.Tasks;
using TeamWorkMVC.Application.InterfacesServices;

namespace TeamWorkMVC.Web.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;
    
    public TaskController(ITaskService taskService, IProjectService projectService, IMapper mapper)
    {
        _taskService = taskService;
        _projectService = projectService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var model = _taskService.GetAllTasksForList();
        
        return View(model);
    }
    
    [HttpGet]
    [Route("Task/Create")]
    public IActionResult AddTask()
    {
        var taskDTO = new TaskCreateDTO();
        var availableProject = _projectService.GetAllProjectsForList().ProjectTo<ProjectForSelectDTO>(_mapper.ConfigurationProvider);

        taskDTO.AvailableProjects = availableProject;
        
        return View(taskDTO);
    }
    
    [HttpGet]
    [Route("Task/Create/{id}")]
    public IActionResult AddTask(int id)
    {
        var taskDTO = new TaskCreateDTO();
        var availableProject = _projectService.GetAllProjectsForList().ProjectTo<ProjectForSelectDTO>(_mapper.ConfigurationProvider).Where(i => i.Id == id);
        
        taskDTO.AvailableProjects = availableProject;
        
        return View(taskDTO);
    }

    [HttpPost]
    [Route("Task/Create/{id}")]
    public IActionResult AddTask(TaskCreateDTO model, int id)
    {
        var index = _taskService.AddTask(model);
        
        return RedirectToAction("Index");
    }    
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _taskService.GetTaskForEdit(id);
       
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskUpdateDTO model)
    {
        var id = _taskService.EditTask(model);
       
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        _taskService.DeleteTask(id);
        
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var task = _taskService.GetTaskById(id);
        
        return View(task);
    }

  
}