using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Domain.Helpers;
using MediatR;


namespace Inventory_System.Core.Features.StockHistories.Commands.Models
{
    public class CreateStockHistoryCommand : IRequest<Result<StockHistoryDto>>
    {
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public string? Notes { get; set; }
        public Guid ProductId { get; set; }
        public Guid? SupplierId { get; set; }

        // Temporary default — replace with authenticated user once JWT/Auth is implemented
        public string CreatedBy { get; set; } = "System";
    }
}