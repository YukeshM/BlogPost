using BlogProject.Interface;
using BlogProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _blog;

        public BlogController(IBlog blog)
        {
            _blog = blog;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAllBlogs()
        {   
                var blog = await _blog.GetAllBlog();
                return blog.ToList();
 
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _blog.GetById(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Blog>> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest("Id mismatch");
            }

            var UpdateBlog = await _blog.GetById(id);

            if (UpdateBlog == null)
            {
                return NotFound();
            }

            return await _blog.Update(blog);

        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            if (blog == null)
            {
                return NotFound();
            }
            var newBlog = await _blog.Insert(blog);

            return CreatedAtAction("GetBlog", new { id = blog.Id },newBlog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            
            var blog = await _blog.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return await _blog.Delete(id);
            

        }

        //private bool BlogExists(int id)
        //{
        //    return _context.BlogTable.Any(e => e.Id == id);
        //}
    }
}
