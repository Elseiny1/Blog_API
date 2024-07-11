using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Blogs.Core.Dtos;
using Personal_Blogs.Core.IRepos;

namespace Personal_Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogs _blogs;
        public BlogController(IBlogs blogs)
        {
            _blogs = blogs;
        }

        [HttpGet("Get All Blogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var allBlogs =await _blogs.GetAllBlogsAsync();
            if(allBlogs is null) 
                return NotFound();
            return Ok(allBlogs);
        }
        [HttpPost("Add New Blog")]
        public async Task<IActionResult> AddNewBlog(BlogDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            await _blogs.AddBlogAsync(model);
            return Ok();
        }
        [HttpGet("Get Blog")]
        public async Task<IActionResult> GetBlog(int id)
        {
            if (id < 0)
                return BadRequest();
            var blog = await _blogs.GetBlogAsync(id);
            if (blog is null)
                return BadRequest();
            return Ok(blog);
        }
        [HttpPut("Update Blog")]
        public async Task<IActionResult> UpdateBlog(BlogDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var blog = await _blogs.UpdateBlogAsync(model);
            if (!blog)
                return BadRequest();
            return Ok(blog);
        }
        [HttpDelete("Delte Blog")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if (id < 0)
                return BadRequest();
            var blog = await _blogs.DeleteBlogAsync(id);
            if (!blog)
                return BadRequest();
            return Ok(blog);
        }


    }
}
