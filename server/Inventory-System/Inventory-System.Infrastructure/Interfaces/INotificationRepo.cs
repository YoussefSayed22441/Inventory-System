using Inventory_System.Domain.Entities;
using Inventory_System.Infrastructure.Interfaces;
using System;
 
namespace Inventory_System.Infrastructure.Interfaces
{
    public interface INotificationRepo : IGenericRepo<Notification>
    {
    }
}