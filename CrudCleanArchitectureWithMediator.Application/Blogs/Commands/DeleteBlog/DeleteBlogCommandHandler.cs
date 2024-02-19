using AutoMapper;
using CrudCleanArchitectureWithMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IblogRepository _blogRepository;
        private readonly IMapper _mapper;
        public DeleteBlogCommandHandler(IMapper mapper, IblogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
           return await _blogRepository.DeleteAsync(request.Id);
        }
    }
}
