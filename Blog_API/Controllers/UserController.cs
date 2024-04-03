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

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = userRepository.GetUsers();

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            else return Ok(users);
        
        }
        [HttpGet("{userid}")]
        public IActionResult GetUser(int userid)
        {
            if (userRepository.Exists(userid))  
                NotFound(ModelState);

            var user = mapper.Map<UserDto>( userRepository.GetUser(userid));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(user);
        }
    }
}
