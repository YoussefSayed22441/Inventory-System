using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IQueryable<Product> GetProducts()
        {
            return _productRepo.GetTableNoTracking()
                .Include(x => x.Category);
        }

        public IQueryable<Product> GetProductsByCategoryId(Guid categoryId)
        {
            return _productRepo.GetTableNoTracking()
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId);
        }

        public IQueryable<Product> GetLowStockProducts()
        {
            return _productRepo.GetTableNoTracking()
                .Include(x => x.Category)
                .Where(x => x.CurrentStock <= x.ReorderLevel);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _productRepo.GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> GetByIdWithIncludeAsync(Guid id)
        {
            return await _productRepo.GetTableNoTracking()
                .Include(x => x.Category)
                .Include(x =>x.ProductSuppliers)
                    .ThenInclude(ps => ps.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> GetBySkuAsync(string sku)
        {
            return await _productRepo.GetTableNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.SKU == sku);
        }

        public async Task<Product?> GetByBarcodeAsync(string barcode)
        {
            return await _productRepo.GetTableNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Barcode == barcode);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _productRepo.IsExist(x=>x.Id == id);
        }

        public async Task<Product?> AddAsync(Product product)
        {
            // SKU must be unique if provided
            if (!string.IsNullOrWhiteSpace(product.SKU))
            {
                var skuExists = await _productRepo.GetTableNoTracking()
                    .AnyAsync(x => x.SKU == product.SKU);

                if (skuExists) return null;
            }

            await _productRepo.AddAsync(product);

            return await _productRepo.GetTableNoTracking()
                .Include(x =>x.Category)
                .FirstOrDefaultAsync(x => x.Id == product.Id);
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            await _productRepo.UpdateAsync(product);
            return product;
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            var transaction = _productRepo.BeginTransaction();
            try
            {
                await _productRepo.DeleteAsync(product);
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
