using System.ComponentModel.DataAnnotations;

namespace Personal_Blogs.Core.Dtos
{
    public class BlogDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        public DateTime Blog_Date { get; set; }

    }
}
