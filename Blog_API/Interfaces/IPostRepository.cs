using ModelsLibrary;
using ModelsLibrary.PostDto;

namespace Blog_API.Interfaces
{
    public interface IPostRepository
    {
        bool Exists (int id );
        ICollection<Post> GetAllPostsForBlog ();
        Post GetPostById ( int id );
        int CountPosts();
        bool SaveChanges();
        bool CreatePost(Post post);
        public Post PostRequestToPost(PostDtoCreateRequest postDtoCreateRequest, int userId);
        public bool UpdatePost(Post post);
        Post GetPostForUpdate(int id);
        string GetUserNameFromPost(int id);
    }
}
