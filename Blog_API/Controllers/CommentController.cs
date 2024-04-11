using AutoMapper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using ModelsLibrary.CommentDto;

namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public CommentController(ICommentRepository commentRepository,IUserRepository userRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateComment([FromBody] CommentDtoCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!userRepository.Exists(comment.User.Username))
                return NotFound();

            var NewComment = commentRepository.CommentCreateToComment(comment,userRepository.GetUserIdByName(comment.User.Username));

            if (!commentRepository.CreateComment(NewComment))
                return BadRequest();
            return Ok();
        }
    }
}
