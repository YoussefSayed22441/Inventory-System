using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Commands.Models;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Service.Abstracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Notifications.Commands.Handlers
{
    public class DeleteNotificationCommandHandler
        : IRequestHandler<DeleteNotificationCommand, Result<bool>>
    {
        private readonly INotificationService _notificationService;

        public DeleteNotificationCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<Result<bool>> Handle(
            DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationService.GetByIdAsync(request.Id);

            if (notification == null)
                return Result<bool>.Failure("Notification Not Found", ResultStatus.NotFound);

            var result = await _notificationService.DeleteAsync(notification);

            if (!result)
                return Result<bool>.Failure("Notification Delete Failed", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "Notification Deleted Successfully.");
        }
    }

    public class MarkNotificationAsReadCommandHandler
        : IRequestHandler<MarkNotificationAsReadCommand, Result<NotificationDto>>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public MarkNotificationAsReadCommandHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<Result<NotificationDto>> Handle(
            MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationService.MarkAsReadAsync(request.Id);

            if (result == null)
                return Result<NotificationDto>.Failure("Notification Not Found", ResultStatus.NotFound);

            var dto = _mapper.Map<NotificationDto>(result);
            return Result<NotificationDto>.Success(dto, "Notification Marked As Read.");
        }
    }

    public class MarkAllNotificationsAsReadCommandHandler
        : IRequestHandler<MarkAllNotificationsAsReadCommand, Result<bool>>
    {
        private readonly INotificationService _notificationService;

        public MarkAllNotificationsAsReadCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<Result<bool>> Handle(
            MarkAllNotificationsAsReadCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationService.MarkAllAsReadAsync();

            if (!result)
                return Result<bool>.Failure("Failed to mark all notifications as read.", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "All Notifications Marked As Read.");
        }
    }
}