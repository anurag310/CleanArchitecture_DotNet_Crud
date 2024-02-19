using AutoMapper;
using CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs;
using CrudCleanArchitectureWithMediator.Domain.Entity;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IblogRepository _blogRepository;
        private readonly IMapper _mapper;
        public UpdateBlogCommandHandler(IMapper mapper, IblogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlogEntity = new Blog()
            {
                Id = request.Id,
                Author = request.Author,
                Name = request.Name,
                Description = request.Description,
            };
            return  await _blogRepository.UpdateAsync(request.Id, updateBlogEntity);
        }
    }
}
