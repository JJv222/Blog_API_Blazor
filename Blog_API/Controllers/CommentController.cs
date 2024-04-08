using AutoMapper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Dto;
using ModelsLibrary;

namespace Blog_API.Controllers
{
    [Route("/[controller]")]
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

        [HttpGet("api/CountCommentsForPost={PostId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult CountCommentsForPost(int PostId)
        {
            var count = commentRepository.GetCommentCount(PostId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(count);

        }

        [HttpGet("api/GetCommentsFromPost={postId}")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        public IActionResult GetComments(int postId)
        {
            var comments = mapper.Map<List<CommentDto>>(commentRepository.GetCommentsByPost(postId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(comments);
        }

        [HttpGet("api/GetCommentsAll")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        public IActionResult GetCommentsAll()
        {
            var comments = mapper.Map<List<CommentDto>>(commentRepository.GetCommentsAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(comments);
        }

        [HttpPost("api/CreateComment/PostId={PostId}&Username={Username}")]
        [ProducesResponseType(201)]
        public IActionResult CreateComment([FromBody] CommentDto comment, string Username,int PostId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var Comment = mapper.Map<Comment>(comment);
            var User1 = userRepository.GetUserByName(Username); 
            Comment.UserId = User1.Id;
            Comment.User = User1;
            Comment.PostId = PostId;

            if(!commentRepository.CreateComment(Comment))
                 return StatusCode(500,ModelState);

            return Ok();

        }
    }
}
