using Blog_API.Data;
using Blog_API.Interfaces;
using ModelsLibrary;
using SQLitePCL;

namespace Blog_API.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly BlogContext blogContext;
        public UserRepository(BlogContext context)
        {
            blogContext = context;
        }

        public bool Exists(int id)
        {
            return blogContext.Users.FirstOrDefault(x=> x.Id == id) != null? true: false;
        }

        public bool Exists(string username)
        {
            return blogContext.Users.FirstOrDefault(x => x.Username == username) != null ? true : false;
        }

        public ICollection<User> GetAllUsers()
        {
            return blogContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return blogContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByName(string username)
        {
            return blogContext.Users.FirstOrDefault(x => x.Username == username);
        }

        public int GetUserIdByName(string username)
        {
            return blogContext.Users.FirstOrDefault(x=> x.Username == username).Id;
        }
    }
}
