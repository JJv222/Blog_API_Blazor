using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Interfaces
{
    public interface IPostRepository
    {
        bool Exists (int id );
        ICollection<Post> GetAllPosts ();
        Post GetPostById ( int id );

    }
}
