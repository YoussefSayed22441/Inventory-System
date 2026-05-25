using Microsoft.AspNetCore.Mvc;
using MediatR;
using Inventory_System.Core.Features.Categories.Queries.Models;
using Inventory_System.Core.Features.Categories.Commands.Models;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : BaseApiController
    {
        private readonly IMediator _mediator;
        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSuppliersQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetSupplierByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteSupplierCommand(id));
            return NewResult(response);
        }
    }
}
