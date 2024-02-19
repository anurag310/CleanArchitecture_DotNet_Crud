using AutoMapper;
using CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IblogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogByIdQueryHandler(IblogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetbyIDAsync(request.BlogId);
            return _mapper.Map<BlogVm>(blog);
        }
    }
}
