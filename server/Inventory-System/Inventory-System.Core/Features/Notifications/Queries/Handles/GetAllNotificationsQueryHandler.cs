using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Core.Features.Notifications.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Notifications.Queries.Handles
{
    public class GetAllNotificationsQueryHandler
        : IRequestHandler<GetAllNotificationsQuery, Result<PaginatedResult<NotificationDto>>>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public GetAllNotificationsQueryHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<NotificationDto>>> Handle(
            GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var query = request.UnreadOnly == true
                ? _notificationService.GetUnreadNotifications()
                : _notificationService.GetNotifications();

            var totalCount = await query.CountAsync(cancellationToken);

            var data = query
                .ProjectTo<NotificationDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<NotificationDto>
                .Success(data, request.PageNumber, totalCount, request.PageSize);

            return Result<PaginatedResult<NotificationDto>>.Success(paginated);
        }
    }
}