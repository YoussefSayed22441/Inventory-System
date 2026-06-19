using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Repositories
{
    public class SupplierRepo : GenericRepo<Supplier>, ISupplierRepo
    {
        private readonly DbSet<Supplier> _suppliers;
        public SupplierRepo(InventoryDbContext dbContext) : base(dbContext)
        {
            _suppliers = dbContext.Set<Supplier>();
        }
    }
}
