using AnonTalkAPI.Data;
using AnonTalkAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnonTalkAPI.Services
{
    public class BoardService : IBoardService
    {
        private readonly AnonTalkAPIContext _context;
        public BoardService(AnonTalkAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Board>> GetBoards()
        {
            var result = await (from board in _context.Boards
                                select board).AsNoTracking().ToListAsync();
            return result;
        }
    }
}
