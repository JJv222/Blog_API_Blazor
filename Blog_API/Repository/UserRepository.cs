using Blog_API.Data;
using Blog_API.Interfaces;
using ModelsLibrary;
using ModelsLibrary.PostDto;
using ModelsLibrary.UserDto;
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
        private bool SaveChanges()
        {
            return blogContext.SaveChanges() >= 0 ? true : false;
        }
        public bool CreateUser(User user)
        {
            blogContext.Add(user);
            return SaveChanges();
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

        public User GetUserByCommentId(int commentId)
        {
            return blogContext.Users.FirstOrDefault(x => x.Id == blogContext.Comments.FirstOrDefault(x => x.Id == commentId).UserId);
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

        public string GetUserRole(string username)
        {
            var user = blogContext.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return ModelsLibrary.Enums.EnumConverter.EnumToString(user.Role);
            }
            else
            {
                return null;
            }

        }
        public User UserCreateToUser(UserDtoPostRequest user)
        {
            return new  User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = ModelsLibrary.Enums.Role.User
            };
        }

        public bool DeleteUser(string username)
        {
            blogContext.Remove(blogContext.Users.FirstOrDefault(x => x.Username == username));
            return SaveChanges();
        }
    }
}
