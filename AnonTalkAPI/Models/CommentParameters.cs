using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.Models
{
    public class CommentParameters
    {
        public string Content { get; set; }
        public bool Image { get; set; }
        public string? ImageBase64 { get; set; }
        public Guid PostId { get; set; }
    }
}
