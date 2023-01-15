using AnonTalkAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.DTO
{
    public class PostReceiveDTO
    {
        public string? Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Image { get; set; }
        public string? ImageBase64 { get; set; }
        [Required]
        public string BoardId { get; set; }
    }
}
