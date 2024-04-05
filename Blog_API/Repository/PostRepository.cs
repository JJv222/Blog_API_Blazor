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
            var posts= blogcontext.Posts.OrderBy(x => x.Id).ToList(); 
            for(int i = 0; i < posts.Count; i++)
            {
                posts[i].User = (User)blogcontext.Users.Where(x => x.Id == posts[i].UserId).FirstOrDefault();
            }
            return posts;
        }

        public Post GetPostById(int id)
        {
            var post = blogcontext.Posts.FirstOrDefault(x => x.Id == id);
            post.User = blogcontext.Users.Where(x => x.Id == post.UserId).FirstOrDefault();
            return post;
        }
        public int CountPosts()
        {
            return blogcontext.Posts.Count();
        }
    }
}
