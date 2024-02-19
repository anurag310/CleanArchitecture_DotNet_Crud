using CrudCleanArchitectureWithMediator.Application.Blogs.Commands.CreateBlog;
using CrudCleanArchitectureWithMediator.Application.Blogs.Commands.DeleteBlog;
using CrudCleanArchitectureWithMediator.Application.Blogs.Commands.UpdateBlog;
using CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogById;
using CrudCleanArchitectureWithMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudCleanArchitectureWithMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createdBlog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateBlogCommand command)
        {
            if( id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlogCommand { Id = id });
            return NoContent();
        }
    }
   
}
