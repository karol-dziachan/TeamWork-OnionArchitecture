using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

   
    
}