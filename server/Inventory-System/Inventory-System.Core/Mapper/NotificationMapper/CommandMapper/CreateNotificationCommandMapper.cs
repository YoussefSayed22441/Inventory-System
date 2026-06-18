using Inventory_System.Core.Features.Notifications.Commands.Models;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.NotificationMapper
{
    public partial class NotificationProfile
    {
        public void CreateNotificationCommandMapper()
        {
            CreateMap<CreateNotificationCommand, Notification>();
        }
    }
}