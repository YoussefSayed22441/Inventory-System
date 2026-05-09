using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Repositories
{
    public class CategoryRepo: GenericRepo<Category>, ICategoryRepo
    {
        private readonly DbSet<Category> _categories;
        public CategoryRepo(InventoryDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<Category>();
        }
    }
}
