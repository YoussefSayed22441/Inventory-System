using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using MediatR;
using System;

namespace Inventory_System.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationByIdQuery : IRequest<Result<NotificationDto>>
    {
        public Guid Id { get; set; }

        public GetNotificationByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}