using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Image { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public Guid PostId { get; set; }
        [Required]
        public Post Post { get; set; }
    }
}
