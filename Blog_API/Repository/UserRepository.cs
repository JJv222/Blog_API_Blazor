using Blog_API.Data;
using Blog_API.Interfaces;
using ModelsLibrary;
using SQLitePCL;

namespace Blog_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext blogContext;
        public UserRepository(BlogContext context)
        {
            blogContext = context;
        }

        public bool Exists(int id)
        {
            return (blogContext.Users.FirstOrDefault(x => x.Id == id) is not null) ? true: false;
        }
        public bool Exists(string username)
        {
            return (blogContext.Users.FirstOrDefault(x => x.Username == username) is not null) ? true : false;
        }
        public User GetUser(int id)
        {
           return blogContext.Users.Where(p => p.Id == id).FirstOrDefault();
        }
        public User GetUser(string username)
        {
            return blogContext.Users.Where(p => p.Username == username).FirstOrDefault();
        }

        public ICollection<User> GetAllUsers()
        {
            return blogContext.Users.OrderBy(x => x.Id).ToList();
        }

    }
}
