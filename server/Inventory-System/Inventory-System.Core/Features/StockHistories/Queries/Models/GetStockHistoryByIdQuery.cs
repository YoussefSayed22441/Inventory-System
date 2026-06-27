using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using MediatR;

namespace Inventory_System.Core.Features.StockHistories.Queries.Models
{
    public class GetStockHistoryByIdQuery : IRequest<Result<StockHistoryDto>>
    {
        public Guid Id { get; set; }

        public GetStockHistoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}