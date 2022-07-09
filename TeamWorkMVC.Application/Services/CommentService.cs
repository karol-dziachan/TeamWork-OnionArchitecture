using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeamWorkMVC.Application.DTOs.Comments;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public int AddComment(CommentCreateDTO model)
    {
        var comment = _mapper.Map<Comment>(model);
        var id = _commentRepository.AddItem(comment);

        return id;
    }

    public IQueryable<CommentForListDTO> GetAllCommentsForList()
    {
        var comments = _commentRepository.GetAllItems();
        var commentsDTO = comments.ProjectTo<CommentForListDTO>(_mapper.ConfigurationProvider);

        return commentsDTO;
    }

    public CommentDetailsDTO GetCommentById(int id)
    {
        var comment = _commentRepository.GetItemById(id);
        var commentDTO = _mapper.Map<CommentDetailsDTO>(comment);

        return commentDTO;
    }

    public CommentUpdateDTO GetCommentForEdit(int id)
    {
        var comment = _commentRepository.GetItemById(id);
        var commentDTO = _mapper.Map<CommentUpdateDTO>(comment);

        return commentDTO;
    }

    public int EditComment(CommentUpdateDTO model)
    {
        var comment = _mapper.Map<Comment>(model);
        var projectId = _commentRepository.EditItem(comment);

        return projectId;
    }

    public int DeleteComment(int id)
    {
        var commentId = _commentRepository.DeleteItem(id);

        return commentId;
    }
}