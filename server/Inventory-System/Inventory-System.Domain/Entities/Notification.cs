using Inventory_System.Domain.Entities;
using Inventory_System.Domain.Entities.Base;
using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; } 
        public string Title { get; set; } 
        public NotificationType Type { get; set; }
        public NotificationPriority Priority { get; set; } 
        public string? Notes { get; set; }
        public bool IsRead { get; set; }
    

        #region Relation With Product
        // Foreign Key (nullable — general notifications may not link to a product)
        public Guid? ProductId { get; set; }// FK

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Product.Notifications))]
        public Product? Product { get; set; }  // Navigation Property
        #endregion

    }

}


