using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.AppUsers;
using TeamWorkMVC.Application.InterfacesServices;

namespace TeamWorkMVC.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminPanelController : Controller
{
    private readonly IUserManagementService _userManagementService;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AdminPanelController(IUserManagementService userManagementService,  RoleManager<IdentityRole> roleManager)
    {
        _userManagementService = userManagementService;
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = _userManagementService.GetAllUsers();
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Edit(string id)
    {
        var user = _userManagementService.GetUserForEdit(id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(UserUpdateDTO model)
    {
        var id = _userManagementService.EditUser(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult SetUserRole(string id)
    {
        var user = _userManagementService.GetUserForEditRole(id);
        return View(user);
    }

    [HttpPost]
    public IActionResult SetUserRole(UserRoleDTO model)
    {

        var userId = _userManagementService.EditUserRole(model);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(string id)
    {
        _userManagementService.DeleteUser(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var user = _userManagementService.GetUserById(id);
        return View(user);
    }
}