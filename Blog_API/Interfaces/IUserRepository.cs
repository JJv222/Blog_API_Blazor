using ModelsLibrary;

namespace Blog_API.Interfaces
{
    public interface IUserRepository
    {
        bool Exists(int id);
        bool Exists(string username);
        ICollection<User> GetAllUsers();
        User GetUser(int id);
        User GetUser(string username);
    }
}
