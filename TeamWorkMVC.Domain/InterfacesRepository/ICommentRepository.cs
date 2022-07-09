using Microsoft.AspNetCore.Http.Features;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Domain.InterfacesRepository;

public interface ICommentRepository
{
    int AddItem(Comment comment);
    IQueryable<Comment> GetAllItems();
    Comment GetItemById(int id);
    int EditItem(Comment comment);
    int DeleteItem(int id);
}