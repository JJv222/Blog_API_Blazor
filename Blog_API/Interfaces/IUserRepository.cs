using ModelsLibrary;

namespace Blog_API.Interfaces
{
    public interface IUserRepository
    {
        bool Exists(int id);
        ICollection<User> GetUsers();
        User GetUser(int id);
    }
}
