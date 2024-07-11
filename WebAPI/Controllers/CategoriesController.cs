using Business.Features.Categories.Commands.Create;
using DataAccess.Contexts;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly AppDbContext _appDbContext;
        public CategoriesController(ISender sender,
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _sender = sender;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand command)
        {
            Category category = new() { Name = command.Name };
            _appDbContext.Categories.Add(category);
             _appDbContext.SaveChanges();
            var result = await _sender.Send(command);
            return Ok(result);
        }

    }
}
