using AnonTalkAPI.DTO;
using AnonTalkAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnonTalkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly IMapper _mapper;
        public BoardController(IBoardService boardService, IMapper mapper)
        {
            _boardService = boardService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetBoards")]
        public async Task<IActionResult> GetBoards()
        {
            var boards = await _boardService.GetBoards();
            var result = _mapper.Map<List<BoardReturnDTO>>(boards);
            return Ok(result);
        }
    }
}
