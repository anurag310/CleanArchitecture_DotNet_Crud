using AutoMapper;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs
{
    // business logic
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IblogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogQueryHandler(IblogRepository blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;

        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
           var blogs = await _blogRepository.GetAllBlogsAsync();
            //var blogList= blogs.Select(x => new BlogVm
            // {
            //     Author = x.Author,
            //     Name = x.Name,
            //     Description = x.Description,
            //     Id = x.Id
            // }).ToList();
            // Map<Destination><Source>
            var blogList = _mapper.Map<List<BlogVm>>(blogs);
            return blogList;
        }
    }
}
