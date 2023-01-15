using AnonTalkAPI.Models;

namespace AnonTalkAPI.Services
{
    public interface IBoardService
    {
        public Task<List<Board>> GetBoards();
    }
}
