using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System.Service.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;

        public SupplierService(ISupplierRepo supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public IQueryable<Supplier> GetSuppliers()
        {
            return _supplierRepo.GetTableNoTracking();
        }

        public async Task<Supplier?> GetByIdAsync(Guid id)
        {
            var supplier = await _supplierRepo
                .GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return supplier;
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _supplierRepo.IsExist(x => x.Id == id);
        }

        public async Task<Supplier?> AddAsync(Supplier supplier)
        {
            var existing = await _supplierRepo
                .GetTableNoTracking()
                .AnyAsync(x => x.Email == supplier.Email);

            if (existing)
                return null;

            await _supplierRepo.AddAsync(supplier);

            var result = await _supplierRepo
                .GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.Id == supplier.Id);

            return result;
        }

        public async Task<Supplier?> UpdateAsync(Supplier supplier)
        {
            await _supplierRepo.UpdateAsync(supplier);
            return supplier;
        }

        public async Task<bool> DeleteAsync(Supplier supplier)
        {
            var transaction = _supplierRepo.BeginTransaction();
            try
            {
                await _supplierRepo.DeleteAsync(supplier);
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
