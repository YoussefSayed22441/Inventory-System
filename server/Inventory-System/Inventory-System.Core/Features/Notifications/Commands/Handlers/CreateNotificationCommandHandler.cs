using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Commands.Models;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Domain.Entities;
using Inventory_System.Service.Abstracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Notifications.Commands.Handlers
{
    public class CreateNotificationCommandHandler
        : IRequestHandler<CreateNotificationCommand, Result<NotificationDto>>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<Result<NotificationDto>> Handle(
            CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Notification>(request);
            var result = await _notificationService.AddAsync(notification);

            if (result == null)
                return Result<NotificationDto>.Failure("Failed to create notification.", ResultStatus.ValidationError);

            var dto = _mapper.Map<NotificationDto>(result);
            return Result<NotificationDto>.Created(dto, "Notification Created Successfully.");
        }
    }
}