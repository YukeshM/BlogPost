using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Interface
{
   public interface IBlog
    {
        Task <IEnumerable<Blog>> GetAllBlog();

        Task <Blog> GetById(int id);

        Task<Blog> Insert(Blog blog);

        Task<Blog> Update(Blog blog);

        Task<Blog> Delete(int id);

        //void Save();
    }
}
