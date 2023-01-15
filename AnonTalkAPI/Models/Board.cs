using System.ComponentModel.DataAnnotations;

namespace AnonTalkAPI.Models
{
    public class Board
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Post> Posts { get; set; }
    }
}
