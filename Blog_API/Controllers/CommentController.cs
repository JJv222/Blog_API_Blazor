using AutoMapper;
using Blog_API.Data;
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
        private readonly IPostRepository posrepository;
        private readonly IMapper mapper;
        public CommentController(ICommentRepository commentRepository,IUserRepository userRepository, IMapper mapper, IPostRepository posrepository)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.posrepository = posrepository;
        }

        [HttpGet("CommentsCount/{postId}")]
        [ProducesResponseType(200,Type =typeof(int))]
        [ProducesResponseType(404)]
        public int CountComments(int postId)
        {
            return commentRepository.GetCommentCount(postId);
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

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateComment(CommentDtoPutRequest comment)
        {
            var existingComment = commentRepository.GetCommentById(comment.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (existingComment == null) 
                return NotFound();
            if(!userRepository.Exists(comment.UserName))
                return NotFound();
            if (!posrepository.Exists(comment.PostId)) 
                return NotFound();

        
            existingComment.Content = comment.Content; 
            existingComment.Date = comment.Date;
            if (!commentRepository.UpdateComment(existingComment))
            {
                return BadRequest();
            }
          
            return  NoContent();
        }
    }
}
