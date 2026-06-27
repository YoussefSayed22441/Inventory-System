using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using Inventory_System.Core.Features.ProductSupplier.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductSupplierController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductSupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/productsupplier/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetSuppliersByProduct(
            [FromRoute] Guid productId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            var response = await _mediator.Send(new GetSuppliersByProductQuery(productId)
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            return NewResult(response);
        }

        // GET api/productsupplier/supplier/{supplierId}
        [HttpGet("supplier/{supplierId}")]
        public async Task<IActionResult> GetProductsBySupplier(
            [FromRoute] Guid supplierId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            var response = await _mediator.Send(new GetProductsBySupplierQuery(supplierId)
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            return NewResult(response);
        }

        // POST api/productsupplier
        [HttpPost]
        public async Task<IActionResult> Assign([FromBody] AssignSupplierToProductCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        // PUT api/productsupplier/cost-price
        [HttpPut("cost-price")]
        public async Task<IActionResult> UpdateCostPrice([FromBody] UpdateSupplierCostPriceCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        // DELETE api/productsupplier/{productId}/{supplierId}
        [HttpDelete("{productId}/{supplierId}")]
        public async Task<IActionResult> Remove([FromRoute] Guid productId, [FromRoute] Guid supplierId)
        {
            var response = await _mediator.Send(new RemoveSupplierFromProductCommand(productId, supplierId));
            return NewResult(response);
        }

    }
}
