using Inventory_System.Domain.Entities;

namespace Inventory_System.Service.Abstracts
{
    public interface ISupplierService
    {
        IQueryable<Supplier> GetSuppliers();
        Task<Supplier?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<Supplier?> AddAsync(Supplier supplier);
        Task<Supplier?> UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(Supplier supplier);
    }
}
