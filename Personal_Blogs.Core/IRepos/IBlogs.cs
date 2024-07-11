using Personal_Blogs.Core.Dtos;
using Personal_Blogs.DAL.Models;

namespace Personal_Blogs.Core.IRepos
{
    public interface IBlogs
    {
        //Calling all blogs been created
        public Task<IQueryable<Blog>> GetAllBlogsAsync();

        //Adding new blog and save it  'C' Create
        public Task AddBlogAsync(BlogDto blog);

        //Calling a single blog by it's id  'R' Read
        public Task<Blog> GetBlogAsync(int id);

        //Calling a single blog and update it  'U' Update
        public Task<bool> UpdateBlogAsync(BlogDto model);

        //Calling a single blog and Delte it   'D' Delete
        public Task<bool> DeleteBlogAsync(int id);
    }
}
