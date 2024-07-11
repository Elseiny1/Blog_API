using Personal_Blogs.Core.Dtos;
using Personal_Blogs.Core.IRepos;
using Personal_Blogs.DAL.Database;
using Personal_Blogs.DAL.Models;

namespace Personal_Blogs.Core.Repos
{
    public class Blogs: IBlogs
    {
        private readonly ApplicationDbContext _context;
        public Blogs(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Blog>> GetAllBlogsAsync()
        {
            var blogs = _context.Blogs;

            return blogs;
        }
        public async Task AddBlogAsync(BlogDto blog)
        {
            var newBlog = new Blog
            {
                Blog_Id = blog.Id,
                Titel = blog.Title,
                Content = blog.Content,
                Blog_Date = DateTime.UtcNow
            };
            _context.Add(newBlog);
            _context.SaveChanges();
        }
        public async Task<Blog> GetBlogAsync(int id)
        {
            var blog =await _context.Blogs.FindAsync(id);

            if (blog is null)
                return null;

            return blog;
        }
        public async Task<bool> UpdateBlogAsync(int id)
        {
            var blog =await GetBlogAsync(id);
            if (blog is null)
                return false;
            blog.Titel = blog.Titel;
            blog.Content = blog.Content;
            blog.Blog_Date = DateTime.UtcNow;

            _context.Update(blog);
            _context.SaveChanges();

            return true;
        }
        public async Task<bool> DeleteBlogAsync(int id)
        {
            var blog = await GetBlogAsync(id);
            if (blog is null)
                return false;

            _context.Remove(blog);
            _context.SaveChanges();

            return true;
        }

    }
}
