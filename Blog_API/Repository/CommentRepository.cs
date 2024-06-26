﻿ using Blog_API.Data;
using Blog_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using ModelsLibrary.CommentDto;

namespace Blog_API.Repository
{
    internal class CommentRepository : ICommentRepository
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
            return saved > 0 ? true : false;
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

        public bool UpdateComment(Comment comment)
        {
            blogContext.Update(comment);
            return SaveChanges();
        }

        public Comment CommenRequestToComment(CommentDtoPutRequest commentRequest, int userId)
        {
            return new Comment
            {
                Date = commentRequest.Date,
                Content = commentRequest.Content,
                PostId = commentRequest.PostId,
                UserId = userId
            };
        }

        public string GetUserNameFromComment(int commentId)
        {
            var comment = blogContext.Comments.Include(p => p.User).FirstOrDefault(x => x.Id == commentId).User.Username;
            return comment;
        }

        public bool DeleteComment(int commentId)
        {
            blogContext.Remove(blogContext.Comments.FirstOrDefault(x => x.Id == commentId));
            return SaveChanges();
        }

        public List<int> GetCommentIdsToDelete(int postId)
        {
            return blogContext.Comments.Where(x => x.PostId == postId).Select(x=> x.Id).ToList();
        }
    }
}