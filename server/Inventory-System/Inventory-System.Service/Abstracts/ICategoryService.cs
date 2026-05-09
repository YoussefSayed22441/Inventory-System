using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Service.Abstracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetCategories();
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category?> GetByIdWithIncludeAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<Category?> AddAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
    }
}
