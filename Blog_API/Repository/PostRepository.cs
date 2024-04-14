using Blog_API.Data;
using Blog_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using ModelsLibrary.PostDto;

namespace Blog_API.Repository
{
    internal class PostRepository : IPostRepository
    {
        private readonly BlogContext blogcontext;

        public PostRepository(BlogContext context) {
            blogcontext = context;
        }

        public int CountPosts()
        {
            return blogcontext.Posts.Count();
        }

        public bool CreatePost(Post post)
        {
            blogcontext.Add(post);
            return SaveChanges();
        }

        public bool Exists(int id)
        {
            return blogcontext.Posts.FirstOrDefault(x => x.Id == id) != null ? true : false;
        }

        public ICollection<Post> GetAllPostsForBlog()
        {
            var posts = blogcontext.Posts.Include(p => p.User).ToList();
            return posts;
        }

        public Post GetPostById(int id)
        {
            var post = blogcontext.Posts
                               .Include(p => p.User)
                               .Include(p => p.Comments)
                                   .ThenInclude(c => c.User)
                               .FirstOrDefault(x => x.Id == id);
            return post;
        }

        public Post GetPostDetails(int id)
        {
            return blogcontext.Posts.FirstOrDefault(x => x.Id == id);
        }

        public Post PostRequestToPost(PostDtoCreateRequest postDtoCreateRequest,int userId )
        {

            return new Post
            {
                Title = postDtoCreateRequest.Title,
                Content = postDtoCreateRequest.Content,
                Date = postDtoCreateRequest.Date,
                UserId = userId
            };
        }

        public bool SaveChanges()
        {
            return blogcontext.SaveChanges() >=0 ? true : false;
        }

        public bool UpdatePost(Post post)
        {
            blogcontext.Update(post);
            return SaveChanges();
        }

        public Post GetPostForUpdate(int id)
        {
           return blogcontext.Posts.FirstOrDefault(x => x.Id == id);
        }

        public string GetUserNameFromPost(int id)
        {
            var post = blogcontext.Posts.Include(p=>p.User).FirstOrDefault(x => x.Id == id);
            return post.User.Username;
        }

        public bool DeletePost(int postId)
        {
            blogcontext.Remove(blogcontext.Posts.FirstOrDefault(x => x.Id == postId));
            return SaveChanges();
        }

        public ICollection<int> GetUserPosts(string Username)
        {
            return blogcontext.Posts.Where(x=> x.User.Username == Username).Select(x => x.Id).ToList();
        }
    }
}
