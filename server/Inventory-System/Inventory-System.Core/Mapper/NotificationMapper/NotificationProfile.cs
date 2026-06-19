using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.NotificationMapper
{
    public partial class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            GetNotificationByIdMapper();
            CreateNotificationCommandMapper();
        }
    }
}