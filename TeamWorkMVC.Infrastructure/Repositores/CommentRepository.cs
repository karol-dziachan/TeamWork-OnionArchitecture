using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;
using TeamWorkMVC.Infrastructure.Abstract;

namespace TeamWorkMVC.Infrastructure.Repositores;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(Context context) : base(context)
    {
    }

    public int AddItem(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
        
        return comment.Id;
    }

    public IQueryable<Comment> GetAllItems()
    {
        return _context.Comments;
    }

    public Comment GetItemById(int id)
    {
        var comment = _context.Comments
            .Include(c => c.Task)
            .Include(u => u.AppUser)
            .FirstOrDefault(c => c.Id == id);

        return comment;
    }

    public int EditItem(Comment comment)
    {
        _context.Comments.Update(comment);
        _context.SaveChanges();
        
        return comment.Id;
    }

    public int DeleteItem(int id)
    {
        var comment = _context.Comments.Find(id);

        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return comment.Id;
        }

        return -1;
    }
}