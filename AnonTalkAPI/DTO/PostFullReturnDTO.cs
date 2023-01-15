using AnonTalkAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.DTO
{
    public class PostFullReturnDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public bool Image { get; set; }
        public string? ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
        public List<CommentReturnDTO> Comments { get; set; }
    }
}
