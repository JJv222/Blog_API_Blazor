using AutoMapper;
using Blog_API.Helper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using ModelsLibrary.Enums;
using ModelsLibrary.UserDto;

namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postrepository;
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public UserController(IUserRepository userRepository, IMapper mapper, IPostRepository postrepository, ICommentRepository commentRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.postrepository = postrepository;
            this.commentRepository = commentRepository;
        }
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(200, Type = typeof(List<UserDto>))]
        public IActionResult GetAllUsers()
        {
            var users = userRepository.GetAllUsers();
            var usersDto = mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("GetAuth={username}")]
        [ProducesResponseType(200, Type = typeof(UserDtoAuth))]
        public IActionResult GetUserAuth(string username)
        {
            if(!ModelState.IsValid)
                BadRequest(ModelState);
            if (userRepository.Exists(username) )
                NotFound(ModelState);

            var user = mapper.Map<UserDtoAuth>(userRepository.GetUserByName(username));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(user);
        }
        [HttpGet("GetRole/{username}")]
        [ProducesResponseType(200, Type = typeof(Role))]
        public IActionResult GetUserRole(string username)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);
            if (userRepository.Exists(username))
                NotFound(ModelState);
            var role = userRepository.GetUserRole(username);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(role);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(201, Type = typeof(UserDtoPostRequest))]
        public IActionResult CreateUser([FromBody] UserDtoPostRequest user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (userRepository.Exists(user.Username))
                return BadRequest(ModelState);
            var userEntity = userRepository.UserCreateToUser(user);
            userRepository.CreateUser(userEntity);
            return CreatedAtAction(nameof(GetUserAuth), new { username = user.Username }, user);
        }

        [HttpDelete("Delete/{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!userRepository.Exists(username))
                return NotFound(ModelState);

            var UserPosts = postrepository.GetUserPosts(username);
            if(UserPosts != null)
            {
                foreach (var postId in UserPosts)
                {
                    var comments = commentRepository.GetCommentIdsToDelete(postId);
                    if (comments != null)
                    {
                        foreach (var commentId in comments)
                        {
                            if (!commentRepository.DeleteComment(commentId))
                            {
                                return BadRequest();
                            }
                        }
                    }
                    if (!postrepository.DeletePost(postId))
                        return BadRequest();
                }
            }
            if(!userRepository.DeleteUser(username))
                return BadRequest();

            return NoContent();
        }
    }
}
