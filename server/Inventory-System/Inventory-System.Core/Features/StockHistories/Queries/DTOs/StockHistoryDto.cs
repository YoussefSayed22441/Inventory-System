using Inventory_System.Domain.Helpers;

namespace Inventory_System.Core.Features.StockHistories.Queries.DTOs
{
    public class StockHistoryDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public string TypeName => Type.ToString();
        public string? Notes { get; set; }

        // Product
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        // Supplier (nullable)
        public Guid? SupplierId { get; set; }
        public string? SupplierName { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}