using CrudCleanArchitectureWithMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Domain.Repository
{
    public interface IblogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetbyIDAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int id,Blog blog);
        Task<int> DeleteAsync(int id);
    }
}
