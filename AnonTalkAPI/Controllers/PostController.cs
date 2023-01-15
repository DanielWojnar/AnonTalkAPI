using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AnonTalkAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnonTalkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetPostsByBoardId/{boardId}")]
        public async Task<IActionResult> GetPostsByBoardId(string boardId)
        {
            var posts = await _postService.GetPostsByBoardId(boardId);
            var result = _mapper.Map<List<PostMinimalReturnDTO>>(posts);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var post = await _postService.GetPostById(postId);
            var result = _mapper.Map<PostFullReturnDTO>(post);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] PostReceiveDTO newPost)
        {
            var postParameters = _mapper.Map<PostParameters>(newPost);
            await _postService.AddPost(postParameters);
            return Ok();
        }
    }
}
