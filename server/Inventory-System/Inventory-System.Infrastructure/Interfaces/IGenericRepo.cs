using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Inventory_System.Infrastructure.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<bool> IsExist(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();// By Defualt
        IDbContextTransaction BeginTransaction();
        void Commmit();
        void RollBack();
    }
}
