using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.InterfacesServices;
using System.Security.Claims;

namespace TeamWorkMVC.Web.Controllers;

[Authorize(Roles = "PM")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IUserManagementService _userManagementService;

    public ProjectController(IProjectService projectService, IUserManagementService userManagementService)
    {
        _projectService = projectService;
        _userManagementService = userManagementService;
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
        var projectDTO = new ProjectCreateDTO();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        projectDTO.AppUserId = userId;

     
        return View(projectDTO);
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
        var project = _projectService.GetProjectForEdit(id);
        project.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return View(project);
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
        var project = _projectService.GetProjectById(id);
        return View(project);
    }
   
    
}