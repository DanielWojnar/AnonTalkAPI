using AnonTalkAPI.Models;

namespace AnonTalkAPI.Services
{
    public interface IPostService
    {
        public Task<List<Post>> GetPostsByBoardId(string boardId);
        public Task<Post?> GetPostById(Guid postId);
        public Task AddPost(PostParameters postParameters);
    }
}
