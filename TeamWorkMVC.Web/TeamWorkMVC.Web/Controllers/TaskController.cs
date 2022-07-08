using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.Tasks;
using TeamWorkMVC.Application.InterfacesServices;

namespace TeamWorkMVC.Web.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
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
        return View(new TaskCreateDTO());
    }

    [HttpPost]
    [Route("Task/Create")]
    public IActionResult AddTask(TaskCreateDTO model)
    {
        var id = _taskService.AddTask(model);
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