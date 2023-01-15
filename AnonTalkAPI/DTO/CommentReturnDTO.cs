using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.DTO
{
    public class CommentReturnDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Image { get; set; }
        public string? ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
