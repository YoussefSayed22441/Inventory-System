using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Core.Wrapper;
using MediatR;

namespace Inventory_System.Core.Features.Notifications.Queries.Models
{
    public class GetAllNotificationsQuery : IRequest<Result<PaginatedResult<NotificationDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool? UnreadOnly { get; set; } = null; // null = all, true = unread only
    }
}