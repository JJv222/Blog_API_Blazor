using ModelsLibrary;

namespace Blog_API.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        bool Exists(int id);
    }
}
