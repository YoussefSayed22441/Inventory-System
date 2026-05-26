using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Domain.Helpers;
using MediatR;
using System;

namespace Inventory_System.Core.Features.Notifications.Commands.Models
{
    public class CreateNotificationCommand : IRequest<Result<NotificationDto>>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public NotificationPriority Priority { get; set; }
        public string? Notes { get; set; }
        public Guid? ProductId { get; set; }

        // Temporary default — replace with authenticated user once JWT/Auth is implemented
        public string CreatedBy { get; set; } = "System";
    }
}