using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Core.Features.Notifications.Queries.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Notifications.Queries.Handles
{
    public class GetNotificationByIdQueryHandler
        : IRequestHandler<GetNotificationByIdQuery, Result<NotificationDto>>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public GetNotificationByIdQueryHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<Result<NotificationDto>> Handle(
            GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationService.GetByIdAsync(request.Id);

            if (notification == null)
                return Result<NotificationDto>.Failure("Notification Not Found", ResultStatus.NotFound);

            var dto = _mapper.Map<NotificationDto>(notification);
            return Result<NotificationDto>.Success(dto);
        }
    }
}