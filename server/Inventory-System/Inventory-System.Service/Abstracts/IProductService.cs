using Inventory_System.Domain.Entities;

namespace Inventory_System.Service.Abstracts
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetProductsByCategoryId(Guid categoryId);
        IQueryable<Product> GetLowStockProducts();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product?> GetByIdWithIncludeAsync(Guid id);
        Task<Product?> GetBySkuAsync(string sku);
        Task<Product?> GetByBarcodeAsync(string barcode);
        Task<bool> ExistsAsync(Guid id);
        Task<Product?> AddAsync(Product product);
        Task<Product?> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);
    }
}
