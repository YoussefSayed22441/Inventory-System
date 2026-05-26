using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Data;
using Inventory_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
 
namespace Inventory_System.Infrastructure.Repositories
{
    public class NotificationRepo : GenericRepo<Notification>, INotificationRepo
    {
        private readonly DbSet<Notification> _notifications;
 
        public NotificationRepo(InventoryDbContext dbContext) : base(dbContext)
        {
            _notifications = dbContext.Set<Notification>();
        }
    }
}