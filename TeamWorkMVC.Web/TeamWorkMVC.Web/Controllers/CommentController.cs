using Microsoft.AspNetCore.Mvc;
using TeamWorkMVC.Application.DTOs.Comments;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.InterfacesServices;
using System.Security.Claims;

namespace TeamWorkMVC.Web.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var model = _commentService.GetAllCommentsForList();
        return View(model);
    }
    
    [HttpGet]
    [Route("Comment/Create")]
    public IActionResult AddComment()
    {
        return View(new CommentCreateDTO());
    }    
    
    [HttpGet]
    [Route("Comment/Create/{id}")]
    public IActionResult AddComment(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var commentDTO = new CommentCreateDTO();
        
        commentDTO.DateTime = DateTime.Now;
        commentDTO.TaskId = id;
        commentDTO.AppUserId = userId;
        
        return View(commentDTO);
    }

    [HttpPost]
    [Route("Comment/Create/{id}")]
    public IActionResult AddComment(CommentCreateDTO model,int id)
    {
        var index = _commentService.AddComment(model);
        return RedirectToAction("Index");
    }     
    
   
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var comment = _commentService.GetCommentForEdit(id);
        return View(comment);
    }

    [HttpPost]
    public IActionResult Edit(CommentUpdateDTO model)
    {
        var id = _commentService.EditComment(model);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        _commentService.DeleteComment(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var task = _commentService.GetCommentById(id);
        return View(task);
    }
}