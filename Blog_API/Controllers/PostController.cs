using AutoMapper;
using Blog_API.Helper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using ModelsLibrary.PostDto;
using ModelsLibrary.UserDto;

namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        // private MyMapper myMapper;
        public PostController(IPostRepository postRepository, IMapper mapper, ICommentRepository comentRepository, IUserRepository userRepository) {
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.commentRepository = comentRepository;
            this.userRepository = userRepository;
        }
        [HttpGet("GetBlog")]
        [ProducesResponseType(200, Type = typeof(List<PostDtoBlogResponse>))]
        [ProducesResponseType(404)]
        public IActionResult GetBlogPosts()
        {
            var posts = mapper.Map<List<PostDtoBlogResponse>>(postRepository.GetAllPostsForBlog());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(posts);
        }

        [HttpGet("GetDetails/{id}")]
        [ProducesResponseType(200, Type = typeof(PostDtoPostResponse))]
        [ProducesResponseType(404)]
        public IActionResult GetPostDetails(int id)
        {
            var post = mapper.Map<PostDtoPostResponse>(postRepository.GetPostById(id));

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpGet("GetPostWhenUpdated/{id}")]
        [ProducesResponseType(200, Type = typeof(PostDtoBlogResponse))]
        [ProducesResponseType(404)]
        public IActionResult GetPost(int id)
        {
            var post = mapper.Map<PostDtoBlogResponse>(postRepository.GetPostById(id));

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(PostDtoCreateRequest))]
        [ProducesResponseType(400)]
        public IActionResult CreatePost([FromBody] PostDtoCreateRequest postDtoCreateRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!userRepository.Exists(postDtoCreateRequest.User.Username))
                return NotFound();

            var userId = userRepository.GetUserIdByName(postDtoCreateRequest.User.Username);
            var post = postRepository.PostRequestToPost(postDtoCreateRequest, userId);

            if (!postRepository.CreatePost(post))
            {
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePost([FromBody] PostDtoPutRequest post)
        {
            var existingPost = postRepository.GetPostForUpdate(post.Id);
            var postUsername = postRepository.GetUserNameFromPost(post.Id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (existingPost == null)
                return NotFound();
            if (!userRepository.Exists(post.UsernName) || postUsername != post.UsernName)
                return NotFound();

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Date = post.Date;
            if (!postRepository.UpdatePost(existingPost))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
