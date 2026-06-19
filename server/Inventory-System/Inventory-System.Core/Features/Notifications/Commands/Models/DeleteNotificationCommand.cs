using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using MediatR;
using System;

namespace Inventory_System.Core.Features.Notifications.Commands.Models
{
    public class DeleteNotificationCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }

        public DeleteNotificationCommand(Guid id)
        {
            Id = id;
        }
    }

    public class MarkNotificationAsReadCommand : IRequest<Result<NotificationDto>>
    {
        public Guid Id { get; set; }

        public MarkNotificationAsReadCommand(Guid id)
        {
            Id = id;
        }
    }

    public class MarkAllNotificationsAsReadCommand : IRequest<Result<bool>>
    {
    }
}