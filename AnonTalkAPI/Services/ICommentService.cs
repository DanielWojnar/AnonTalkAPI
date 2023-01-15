using AnonTalkAPI.Models;

namespace AnonTalkAPI.Services
{
    public interface ICommentService
    {
        public Task AddComment(CommentParameters commentParameters);
    }
}
