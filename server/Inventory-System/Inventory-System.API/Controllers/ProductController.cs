using Inventory_System.Core.Features.Products.Commands.Models;
using Inventory_System.Core.Features.Products.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory([FromRoute] Guid categoryId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var response = await _mediator.Send(new GetProductsByCategoryQuery(categoryId)
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            return NewResult(response);
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock([FromQuery] GetLowStockProductsQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }
    }
}
