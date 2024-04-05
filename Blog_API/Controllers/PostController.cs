using AutoMapper;
using Blog_API.Interfaces;
using Blog_API.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public PostController(IPostRepository postRepository, IMapper mapper, ICommentRepository comentRepository, IUserRepository userRepository) { 
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.commentRepository = comentRepository;
            this.userRepository = userRepository;
        }
        [HttpGet("api/GetPostsNumber")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetPostsNumber()
        {
            var ammount = postRepository.CountPosts();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(ammount);
        }

        [HttpGet("api/GetAllPostsBasic")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostDto>))]
        public IActionResult GetAllPostsBasic()
        {
            var posts = mapper.Map<List<PostDto>>(postRepository.GetAllPosts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(posts);
        }

        [HttpGet("api/GetPostBasic={postId}")]
        [ProducesResponseType(200, Type = typeof(PostDto))]
        public IActionResult GetPostBasic(int postId)
        {
            if (postRepository.Exists(postId))
                NotFound(ModelState);

            var post1 = postRepository.GetPostById(postId);
            Console.Write(post1.User.Username + " " + post1.User.Email);
            var post = mapper.Map<PostDto>(postRepository.GetPostById(postId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else return Ok(post);
        }

        [HttpGet("api/GetPost={postId}")]
        [ProducesResponseType(200, Type = typeof(PostDto))]
        public IActionResult GetPost(int postId)
        {
            if(postRepository.Exists(postId)) 
                  NotFound(ModelState);

            var posts = mapper.Map<PostDto>(postRepository.GetPostById(postId));
            posts.Comments = mapper.Map<List<CommentDto>>(commentRepository.GetCommentsByPost(postId));

            if(!ModelState.IsValid) 
                return BadRequest(ModelState); 
            else return Ok(posts);
        }
    }
}
