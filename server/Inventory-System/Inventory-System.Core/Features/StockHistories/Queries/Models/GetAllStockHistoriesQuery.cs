using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Core.Wrapper;
using Inventory_System.Domain.Helpers;
using MediatR;

namespace Inventory_System.Core.Features.StockHistories.Queries.Models
{
    public class GetAllStockHistoriesQuery : IRequest<Result<PaginatedResult<StockHistoryDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Optional Filters
        public Guid? ProductId { get; set; }
        public Guid? SupplierId { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}