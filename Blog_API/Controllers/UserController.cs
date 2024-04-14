using AutoMapper;
using Blog_API.Helper;
using Blog_API.Interfaces;
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
        private readonly IMapper mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
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
    }
}
