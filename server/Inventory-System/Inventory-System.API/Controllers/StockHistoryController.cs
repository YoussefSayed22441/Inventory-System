using Inventory_System.Core.Features.StockHistories.Commands.Models;
using Inventory_System.Core.Features.StockHistories.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class StockHistoryController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StockHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all stock transactions (paginated) with optional filters:
        /// ProductId, SupplierId, Type (0=IN, 1=OUT, 2=ADJUSTMENT), FromDate, ToDate
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStockHistoriesQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        /// <summary>
        /// Get a single stock transaction by Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetStockHistoryByIdQuery(id));
            return NewResult(response);
        }

        /// <summary>
        /// Record a new stock transaction (IN / OUT / ADJUSTMENT).
        /// Automatically updates Product.CurrentStock.
        /// OUT transactions are rejected if stock is insufficient.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockHistoryCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}