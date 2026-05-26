using Inventory_System.Domain.Entities;
using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Inventory_System.Service.Abstracts
{
    public interface INotificationService
    {
        IQueryable<Notification> GetNotifications();
        IQueryable<Notification> GetUnreadNotifications();
        Task<Notification?> GetByIdAsync(Guid id);
        Task<Notification?> AddAsync(Notification notification);
        Task<Notification?> MarkAsReadAsync(Guid id);
        Task<bool> MarkAllAsReadAsync();
        Task<bool> DeleteAsync(Notification notification);
    }
}