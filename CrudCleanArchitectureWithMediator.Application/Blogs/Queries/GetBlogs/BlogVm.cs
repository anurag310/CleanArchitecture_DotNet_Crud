using AutoMapper;
using CrudCleanArchitectureWithMediator.Application.Common.Mapping;
using CrudCleanArchitectureWithMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm : IMapperForm<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
