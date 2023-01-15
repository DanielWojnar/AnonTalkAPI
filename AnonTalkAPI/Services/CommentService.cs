using AnonTalkAPI.Data;
using AnonTalkAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnonTalkAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly AnonTalkAPIContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public CommentService(AnonTalkAPIContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task AddComment(CommentParameters commentParameters)
        {
            var newComment = _mapper.Map<Comment>(commentParameters);
            newComment.UploadDate = DateTime.Now;
            await _context.AddAsync(newComment);
            await _context.SaveChangesAsync();
            if (newComment.Image)
            {
                await File.WriteAllBytesAsync(_env.ContentRootPath + Constants.Comment.CommentImagePath + newComment.Id + Constants.Comment.CommentImageExt, Convert.FromBase64String(commentParameters.ImageBase64));
            }
            var parentPost = await (from post in _context.Posts
                                    where post.Id == newComment.PostId
                                    select post).FirstOrDefaultAsync();
            if (parentPost != null)
            {
                parentPost.BumpDate = newComment.UploadDate;
                await _context.SaveChangesAsync();
            }
        }
    }
}
