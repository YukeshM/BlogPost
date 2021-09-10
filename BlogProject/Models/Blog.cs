using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Blog
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Blog Title is required")]
        public string BlogTitle { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Content should be maximum 1000 words only.")]
        public string Content { get; set; }
    }
}
