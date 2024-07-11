namespace Personal_Blogs.DAL.Models
{
    public class Blog
    {
        [Key]
        public int Blog_Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Titel { get; set; }

        [MaxLength(250)]
        public string Content { get; set; }

        public DateTime Blog_Date { get; set; }
    }
}
