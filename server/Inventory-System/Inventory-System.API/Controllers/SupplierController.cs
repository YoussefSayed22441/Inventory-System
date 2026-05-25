using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            return NewResult(response);
        }
}
