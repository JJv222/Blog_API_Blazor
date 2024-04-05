using AutoMapper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Dto;

namespace Blog_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
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
    }
}
