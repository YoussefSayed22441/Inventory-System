using Inventory_System.Domain.Helpers;
using System;

namespace Inventory_System.Core.Features.Notifications.Queries.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public string TypeName => Type.ToString();
        public NotificationPriority Priority { get; set; }
        public string PriorityName => Priority.ToString();
        public string? Notes { get; set; }
        public bool IsRead { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}