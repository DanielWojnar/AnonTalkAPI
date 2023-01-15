using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AnonTalkAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnonTalkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentReceiveDTO newComment)
        {
            var commentParameteres = _mapper.Map<CommentParameters>(newComment);
            await _commentService.AddComment(commentParameteres);
            return Ok();
        }
    }
}
