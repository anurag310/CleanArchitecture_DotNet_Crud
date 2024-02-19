using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVm>> // returntype blogvm
    {
    }
    //   public record GetBlogQuery : IRequest<List<BlogVm>>;
}
