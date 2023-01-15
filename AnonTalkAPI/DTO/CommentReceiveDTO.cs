using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.DTO
{
    public class CommentReceiveDTO
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Image { get; set; }
        public string? ImageBase64 { get; set; }
        [Required]
        public Guid PostId { get; set; }
    }
}
