using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.InterfacesServices;

namespace TeamWorkMVC.Web.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        var model = _projectService.GetAllProjectsForList();
        return View(model);
    }
    
    [HttpGet]
    [Route("Project/Create")]
    public IActionResult AddProject()
    {
        return View(new ProjectCreateDTO());
    }

    [HttpPost]
    [Route("Project/Create")]
    public IActionResult AddProject(ProjectCreateDTO model)
    {
        var id = _projectService.AddProject(model);
        return RedirectToAction("Index");
    }    
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _projectService.GetProjectForEdit(id);
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(ProjectUpdateDTO model)
    {
        var id = _projectService.EditProject(model);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        _projectService.DeleteProject(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var task = _projectService.GetProjectById(id);
        return View(task);
    }
   
    
}