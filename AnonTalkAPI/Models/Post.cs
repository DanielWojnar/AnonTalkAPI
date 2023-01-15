using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Image { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public DateTime BumpDate { get; set; }
        [Required]
        public string BoardId { get; set; }
        [Required]
        public Board Board { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
