using ModelsLibrary;

namespace Blog_API.Interfaces
{
    public interface IUserRepository
    {
        bool Exists(int id);
        bool Exists(string username);
        ICollection<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByName(string username);
        User GetUserByCommentId(int commentId);
        int GetUserIdByName(string username);
        string GetUserRole(string username);
    }
}
