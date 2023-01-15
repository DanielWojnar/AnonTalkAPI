using AnonTalkAPI.Data;
using AnonTalkAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnonTalkAPI.Services
{
    public class PostService : IPostService
    {
        private readonly AnonTalkAPIContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public PostService(AnonTalkAPIContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task<List<Post>> GetPostsByBoardId(string boardId)
        {
            var result = await (from post in _context.Posts
                                where post.BoardId == boardId
                                orderby post.BumpDate descending
                                select post).Take(Constants.Board.MaxPostsOnBoard).Include(x => x.Comments.OrderBy(x => x.UploadDate)).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Post?> GetPostById(Guid postId)
        {
            var result = await (from post in _context.Posts
                                where post.Id == postId
                                select post).Include(x => x.Comments.OrderBy(x => x.UploadDate)).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }

        public async Task AddPost(PostParameters postParameters)
        {
            var newPost = _mapper.Map<Post>(postParameters);
            newPost.UploadDate = DateTime.Now;
            newPost.BumpDate = DateTime.Now;
            await _context.AddAsync(newPost);
            await _context.SaveChangesAsync();
            if (newPost.Image)
            {
                await File.WriteAllBytesAsync(_env.ContentRootPath + Constants.Post.PostImagePath + newPost.Id + Constants.Post.PostImageExt, Convert.FromBase64String(postParameters.ImageBase64));
            }
        }
    }
}
