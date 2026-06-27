using Inventory_System.Domain.Entities;
using Inventory_System.Domain.Helpers;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Service.Implementations
{
    public class StockHistoryService : IStockHistoryService
    {
        private readonly IStockHistoryRepo _stockHistoryRepo;
        private readonly IProductRepo _productRepo;

        public StockHistoryService(IStockHistoryRepo stockHistoryRepo, IProductRepo productRepo)
        {
            _stockHistoryRepo = stockHistoryRepo;
            _productRepo = productRepo;
        }

        public IQueryable<StockHistory> GetStockHistories(
            Guid? productId,
            Guid? supplierId,
            TransactionType? type,
            DateTime? fromDate,
            DateTime? toDate)
        {
            var query = _stockHistoryRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Supplier)
                .AsQueryable();

            if (productId.HasValue)
                query = query.Where(x => x.ProductId == productId.Value);

            if (supplierId.HasValue)
                query = query.Where(x => x.SupplierId == supplierId.Value);

            if (type.HasValue)
                query = query.Where(x => x.Type == type.Value);

            if (fromDate.HasValue)
                query = query.Where(x => x.CreatedAt >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(x => x.CreatedAt <= toDate.Value);

            return query.OrderByDescending(x => x.CreatedAt);
        }

        public async Task<StockHistory?> GetByIdAsync(Guid id)
        {
            return await _stockHistoryRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StockHistory?> AddAsync(StockHistory stockHistory)
        {
            // Get product with tracking to update stock
            var product = await _productRepo.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.Id == stockHistory.ProductId);

            if (product == null) return null;

            // Check stock for OUT transactions
            if (stockHistory.Type == TransactionType.OUT && product.CurrentStock < stockHistory.Quantity)
                return null;

            var transaction = _stockHistoryRepo.BeginTransaction();
            try
            {
                // Update product stock based on transaction type
                switch (stockHistory.Type)
                {
                    case TransactionType.IN:
                        product.CurrentStock += stockHistory.Quantity;
                        break;

                    case TransactionType.OUT:
                        product.CurrentStock -= stockHistory.Quantity;
                        break;

                    case TransactionType.ADJUSTMENT:
                        product.CurrentStock = stockHistory.Quantity;
                        break;
                }

                product.UpdatedAt = DateTime.UtcNow;
                await _productRepo.UpdateAsync(product);

                // Save the stock history record
                await _stockHistoryRepo.AddAsync(stockHistory);

                await transaction.CommitAsync();

                return await _stockHistoryRepo.GetTableNoTracking()
                    .Include(x => x.Product)
                    .Include(x => x.Supplier)
                    .FirstOrDefaultAsync(x => x.Id == stockHistory.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                return null;
            }
        }
    }
}