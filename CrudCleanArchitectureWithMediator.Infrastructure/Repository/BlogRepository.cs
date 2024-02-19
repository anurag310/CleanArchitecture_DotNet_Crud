using CrudCleanArchitectureWithMediator.Domain.Entity;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using CrudCleanArchitectureWithMediator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Infrastructure.Repository
{
    public class BlogRepository : IblogRepository
    {
        private readonly BlogDbContext _dbContext;
        public BlogRepository(BlogDbContext blogDbContext)
        {
            _dbContext = blogDbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Blogs.
                Where(m => m.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
           return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetbyIDAsync(int id)
        {
            return await _dbContext.Blogs
                .AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _dbContext.Blogs.Where(m => m.Id == id)
                .ExecuteUpdateAsync(s => s
                
                .SetProperty(s => s.Name, blog.Name)
                .SetProperty(s => s.Description, blog.Description)
                .SetProperty(s => s.Author, blog.Author)
                );
        }
    }
}
