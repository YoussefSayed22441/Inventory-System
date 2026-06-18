using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using Inventory_System.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Service.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepo _notificationRepo;

        public NotificationService(INotificationRepo notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        public IQueryable<Notification> GetNotifications()
        {
            return _notificationRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .OrderByDescending(x => x.CreatedAt);
        }

        public IQueryable<Notification> GetUnreadNotifications()
        {
            return _notificationRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .Where(x => !x.IsRead)
                .OrderByDescending(x => x.CreatedAt);
        }

        public async Task<Notification?> GetByIdAsync(Guid id)
        {
            return await _notificationRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Notification?> AddAsync(Notification notification)
        {
            await _notificationRepo.AddAsync(notification);

            return await _notificationRepo.GetTableNoTracking()
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == notification.Id);
        }

        public async Task<Notification?> MarkAsReadAsync(Guid id)
        {
            var notification = await _notificationRepo.GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (notification == null) return null;

            notification.IsRead = true;
            notification.UpdatedAt = DateTime.UtcNow;

            await _notificationRepo.UpdateAsync(notification);

            return notification;
        }

        public async Task<bool> MarkAllAsReadAsync()
        {
            var transaction = _notificationRepo.BeginTransaction();
            try
            {
                var unread = await _notificationRepo.GetTableAsTracking()
                    .Where(x => !x.IsRead)
                    .ToListAsync();

                foreach (var n in unread)
                {
                    n.IsRead = true;
                    n.UpdatedAt = DateTime.UtcNow;
                }

                await _notificationRepo.UpdateRangeAsync(unread);
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Notification notification)
        {
            var transaction = _notificationRepo.BeginTransaction();
            try
            {
                await _notificationRepo.DeleteAsync(notification);
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