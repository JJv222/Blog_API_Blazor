using ModelsLibrary;
using ModelsLibrary.CommentDto;

namespace Blog_API.Interfaces
{
    public interface ICommentRepository
    {
        bool Exists(int Id);
        ICollection<Comment> GetCommentsByPost(int PostId);
        Comment GetCommentById(int Id);
        int GetCommentCount(int PostId);
        ICollection<Comment> GetCommentsAll();
        bool SaveChanges();
        bool CreateComment(Comment comment);
        Comment CommentCreateToComment(CommentDtoCreate commentCreate,int userId);
        bool UpdateComment(Comment comment);
        Comment CommenRequestToComment(CommentDtoPutRequest commentRequest, int userId);
        string GetUserNameFromComment(int commentId);
        bool DeleteComment(int commentId);
        List<int> GetCommentIdsToDelete(int postId);
    }
}
