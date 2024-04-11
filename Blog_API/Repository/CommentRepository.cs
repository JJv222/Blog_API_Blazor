using Blog_API.Data;
using Blog_API.Interfaces;
using ModelsLibrary;
using ModelsLibrary.CommentDto;

namespace Blog_API.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext blogContext;

        public CommentRepository(BlogContext context)
        {
            blogContext = context;
        }
        public bool Exists(int Id)
        {
            return (blogContext.Comments.FirstOrDefault(x => x.Id == Id) is not null) ? true : false;
        }

        public Comment GetCommentById(int Id)
        {
            return blogContext.Comments.FirstOrDefault(x => x.Id == Id);
        }

        public int GetCommentCount(int PostId)
        {
            return blogContext.Comments.Where(x => x.PostId == PostId).Count();
        }

        public ICollection<Comment> GetCommentsByPost(int PostId)
        {
            return blogContext.Comments.Where(x => x.PostId == PostId).ToList();
        }
        public ICollection<Comment> GetCommentsAll()
        {
            return blogContext.Comments.ToList();
        }

        public bool SaveChanges()
        {
            var saved = blogContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool CreateComment(Comment comment)
        {
            blogContext.Add(comment);
            return SaveChanges();
        }

        public Comment CommentCreateToComment(CommentDtoCreate commentCreate,int userId)
        {
            return new Comment
            {
                Date = commentCreate.Date,
                Content = commentCreate.Content,
                PostId = commentCreate.PostId,
                UserId = userId
            };
            
        }
    }
}