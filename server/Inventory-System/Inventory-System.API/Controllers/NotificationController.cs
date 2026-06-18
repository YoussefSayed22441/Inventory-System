using Inventory_System.Core.Features.Notifications.Commands.Models;
using Inventory_System.Core.Features.Notifications.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : BaseApiController
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all notifications (paginated). Pass UnreadOnly=true to filter unread.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationsQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        /// <summary>
        /// Get a single notification by Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetNotificationByIdQuery(id));
            return NewResult(response);
        }

        /// <summary>
        /// Create a new notification manually (e.g. system/admin triggered).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        /// <summary>
        /// Mark a single notification as read.
        /// </summary>
        [HttpPatch("{id}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new MarkNotificationAsReadCommand(id));
            return NewResult(response);
        }

        /// <summary>
        /// Mark ALL notifications as read.
        /// </summary>
        [HttpPatch("mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var response = await _mediator.Send(new MarkAllNotificationsAsReadCommand());
            return NewResult(response);
        }

        /// <summary>
        /// Delete a notification by Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteNotificationCommand(id));
            return NewResult(response);
        }
    }
}