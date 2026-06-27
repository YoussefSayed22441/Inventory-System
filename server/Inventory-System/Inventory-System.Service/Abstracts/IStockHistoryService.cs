using Inventory_System.Domain.Entities;
using Inventory_System.Domain.Helpers;

namespace Inventory_System.Service.Abstracts
{
    public interface IStockHistoryService
    {
        IQueryable<StockHistory> GetStockHistories(
            Guid? productId,
            Guid? supplierId,
            TransactionType? type,
            DateTime? fromDate,
            DateTime? toDate);

        Task<StockHistory?> GetByIdAsync(Guid id);
        Task<StockHistory?> AddAsync(StockHistory stockHistory);
    }
}