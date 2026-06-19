using Inventory_System.Core.Features.Notifications.Queries.DTOs;
using Inventory_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.NotificationMapper
{
    public partial class NotificationProfile
    {
        public void GetNotificationByIdMapper()
        {
            //        Source          Dest
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : null));
        }
    }
}