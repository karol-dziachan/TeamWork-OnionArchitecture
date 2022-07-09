using TeamWorkMVC.Application.DTOs.Comments;

namespace TeamWorkMVC.Application.InterfacesServices;

public interface ICommentService
{
    int AddComment(CommentCreateDTO model);
    
    IQueryable<CommentForListDTO> GetAllCommentsForList();
    
    CommentDetailsDTO GetCommentById(int id);

    CommentUpdateDTO GetCommentForEdit(int id);

    int EditComment(CommentUpdateDTO model);

    int DeleteComment(int id);
}