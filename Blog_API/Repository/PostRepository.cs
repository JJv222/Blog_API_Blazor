using Blog_API.Data;
using Blog_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext blogcontext;

        public PostRepository(BlogContext context) {
            blogcontext = context;
        }
        public bool Exists(int id)
        {
            return (blogcontext.Posts.FirstOrDefault(x => x.Id == id) is not null) ? true: false;
        }

        public ICollection<Post> GetAllPosts()
        {
            return blogcontext.Posts.Include(p => p.User).Include(p => p.Comments).ToList();
        }

        public Post GetPostById(int id)
        {
            return blogcontext.Posts.Include(p=> p.User).Include(p=> p.Comments).FirstOrDefault(x=>x.Id == id);
        }
        public int CountPosts()
        {
            return blogcontext.Posts.Count();
        }

        public bool SaveChanges()
        {
            var saved = blogcontext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool CreatePost(Post post)
        {
            blogcontext.Add(post);
            return SaveChanges();
        }
    }
}
