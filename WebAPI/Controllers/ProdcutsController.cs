using Business.Features.Products.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdcutsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProdcutsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
    }
}
