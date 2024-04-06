using AutoMapper;
using Blog_API.Helper;
using Blog_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Controllers
{
    [Route("/[controller]")]
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

        [HttpGet("api/GetAllUsers")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserDto>))]
        public IActionResult GetAllUsers()
        {
            var users = mapper.Map<List<UserDto>>( userRepository.GetAllUsers());
            foreach (var user in users)
            {
                user.Password = null;
            }
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            else return Ok(users);
        
        }

        [HttpGet("api/GetUser={userid}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public IActionResult GetUser(int userid)
        {
            if (userRepository.Exists(userid))  
                NotFound(ModelState);

            var user = mapper.Map<UserDto>( userRepository.GetUser(userid));
            user.Password = null;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(user);
        }

        [HttpGet("api/GetUserAuth={username}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public IActionResult GetUserAuth(string username)
        {
            if (userRepository.Exists(username))
                NotFound(ModelState);

            var user = mapper.Map<UserDto>(userRepository.GetUser(username));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(user);
        }
    }
}
