using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Implementations
{
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IProductSupplierRepo _productSupplierRepo;

        public ProductSupplierService(IProductSupplierRepo productSupplierRepo)
        {
            _productSupplierRepo = productSupplierRepo;
        }


        public IQueryable<ProductSupplier> GetSuppliersByProductId(Guid productId)
        {
            return _productSupplierRepo.GetTableNoTracking()
                .Include(x => x.Supplier)
                .Where(x => x.ProductId == productId);
        }

        public IQueryable<ProductSupplier> GetProductsBySupplierId(Guid supplierId)
        {
            return _productSupplierRepo.GetTableNoTracking()
                .Include(x => x.Product)
                    .ThenInclude(p => p.Category)
                .Where(x => x.SupplierId == supplierId);
        }

        public async Task<ProductSupplier?> GetByIdAsync(Guid id)
        {
            return await _productSupplierRepo.GetTableNoTracking()
                .Include(x=> x.Product)
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductSupplier?> GetByIdsAsync(Guid productId, Guid supplierId)
        {
            return await _productSupplierRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.SupplierId == supplierId);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _productSupplierRepo.IsExist(x => x.Id == id);
        }

        public async Task<bool> ExistsByIdsAsync(Guid productId, Guid supplierId)
        {
            return await _productSupplierRepo
                .IsExist(x => x.ProductId == productId && x.SupplierId == supplierId);
        }

        public async Task<ProductSupplier?> AssignAsync(ProductSupplier productSupplier)
        {
            //Prevent Duplicate Assignment
            var alreadyExists = await ExistsByIdsAsync(productSupplier.ProductId, productSupplier.SupplierId);
            if (alreadyExists) return null;

            await _productSupplierRepo.AddAsync(productSupplier);

            return await GetByIdsAsync(productSupplier.ProductId, productSupplier.SupplierId);
        }

        public async Task<ProductSupplier?> UpdateCostPriceAsync(ProductSupplier productSupplier)
        {
            await _productSupplierRepo.UpdateAsync(productSupplier);
            return productSupplier;
        }   
        
        public async Task<bool> RemoveAsync(ProductSupplier productSupplier)
        {
            var transaction = _productSupplierRepo.BeginTransaction();
            try
            {
                await _productSupplierRepo.DeleteAsync(productSupplier);
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
