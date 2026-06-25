using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Repositories
{
    public class ProductSupplierRepo : GenericRepo<ProductSupplier>, IProductSupplierRepo
    {
        private readonly DbSet<ProductSupplier> _productSuppliers;

        public ProductSupplierRepo(InventoryDbContext dbContext) : base(dbContext)
        {
            _productSuppliers = dbContext.Set<ProductSupplier>();
        }
    }
}
