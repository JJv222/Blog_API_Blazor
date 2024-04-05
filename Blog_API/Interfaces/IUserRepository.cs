using ModelsLibrary;

namespace Blog_API.Interfaces
{
    public interface IUserRepository
    {
        bool Exists(int id);
        ICollection<User> GetAllUsers();
        User GetUser(int id);
    }
}
