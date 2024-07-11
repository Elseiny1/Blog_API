using Personal_Blogs.Core.Dtos;
using Personal_Blogs.DAL.Models;

namespace Personal_Blogs.Core.IRepos
{
    public interface IBlogs
    {
        public Task<IQueryable<Blog>> GetAllBlogsAsync();
        public Task AddBlogAsync(BlogDto blog);
        public Task<Blog> GetBlogAsync(int id);
        public Task<bool> UpdateBlogAsync(int id);
        public Task<bool> DeleteBlogAsync(int id);
    }
}
