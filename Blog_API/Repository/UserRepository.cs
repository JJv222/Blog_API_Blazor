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

        public User GetUser(int id)
        {
           return blogContext.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return blogContext.Users.OrderBy(x => x.Id).ToList();
        }

    }
}
