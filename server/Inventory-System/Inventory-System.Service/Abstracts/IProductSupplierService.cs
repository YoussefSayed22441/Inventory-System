using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Abstracts
{
    public interface IProductSupplierService
    {
        IQueryable<ProductSupplier> GetSuppliersByProductId(Guid productId);
        IQueryable<ProductSupplier> GetProductsBySupplierId(Guid supplierId);
        Task<ProductSupplier?> GetByIdAsync(Guid id);
        Task<ProductSupplier?> GetByIdsAsync(Guid productId, Guid supplierId);
        Task<bool> ExistAsync(Guid id);
        Task<bool> ExistsByIdsAsync(Guid productId, Guid supplierId);
        Task<ProductSupplier?> AssignAsync(ProductSupplier productSupplier);
        Task<ProductSupplier?> UpdateCostPriceAsync(ProductSupplier productSupplier);
        Task<bool> RemoveAsync(ProductSupplier productSupplier);




    }
}
