using Blog_API.Data;
using Blog_API.Interfaces;
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
            return blogcontext.Posts.OrderBy(x => x.Id).ToList(); 
        }

        public Post GetPostById(int id)
        {
            var post = blogcontext.Posts.FirstOrDefault(x => x.Id == id);
            return post;
        }
    }
}
