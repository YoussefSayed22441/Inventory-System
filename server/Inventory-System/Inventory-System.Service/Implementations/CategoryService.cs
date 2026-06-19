using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IQueryable<Category> GetCategories()
        {
            return _categoryRepo.GetTableNoTracking();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepo
               .GetTableNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }
        public async Task<Category?> GetByIdWithIncludeAsync(Guid id)
        {
            var category = await _categoryRepo.GetTableNoTracking()
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _categoryRepo.IsExist(x => x.Id == id);
        }

        public async Task<Category?> AddAsync(Category category)
        {
            var existing = await _categoryRepo.GetTableNoTracking()
           .AnyAsync(x => x.CategoryName == category.CategoryName);

            if (existing)
                return null;

            await _categoryRepo.AddAsync(category);
            var result = await _categoryRepo
             .GetTableNoTracking()
             .Include(x => x.Products)
             .FirstOrDefaultAsync(x => x.Id == category.Id);

            return result;
        }


        public async Task<Category?> UpdateAsync(Category category)
        {
            await _categoryRepo.UpdateAsync(category);
            return category;
        }

        public async Task<bool> DeleteAsync(Category category)
        {

            var transaction = _categoryRepo.BeginTransaction();
            try
            {
                await _categoryRepo.DeleteAsync(category);
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
