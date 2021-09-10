using BlogProject.Data;
using BlogProject.Interface;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Repository
{
    public class BlogRepository : IBlog
    {

        private readonly ApplicationDbContext _db;

        public BlogRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Blog> Delete(int id)
        {
            var delBlog = await _db.BlogTable.FirstOrDefaultAsync(x => x.Id ==id);
            if (delBlog != null)
            {
                _db.BlogTable.Remove(delBlog);
                await _db.SaveChangesAsync();
                return delBlog;
            }
            return null;
        }

        public async Task<IEnumerable<Blog>> GetAllBlog()
        {
            return await _db.BlogTable.ToListAsync();
        }

        public async Task<Blog> GetById(int Id)
        {
            return await _db.BlogTable.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Blog> Insert(Blog blog)
        {
            var newBlog = await _db.BlogTable.AddAsync(blog);
            await _db.SaveChangesAsync();
            return newBlog.Entity;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public async Task<Blog> Update(Blog blog)
        {

            var newBlog = await _db.BlogTable.FirstOrDefaultAsync(x => x.Id == blog.Id);

            if (newBlog != null)
            {
                newBlog.BlogTitle = blog.BlogTitle;
                newBlog.Content = blog.Content;

                await _db.SaveChangesAsync();
                return newBlog;
            }
            return null;
        }
    }
}
