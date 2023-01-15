using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.Models
{
    public class PostParameters
    {
        public string? Title { get; set; }
        public string Content { get; set; }
        public bool Image { get; set; }
        public string? ImageBase64 { get; set; }
        public string BoardId { get; set; }
    }
}
