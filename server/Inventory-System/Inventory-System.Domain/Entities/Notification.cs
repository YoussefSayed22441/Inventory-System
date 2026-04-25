using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }// we want to use Guid for uniqueness
        public string Message { get; set; } = null!;
        public string Title { get; set; } = null!;
        public NotificationType Type { get; set; } 
        public NotificationPriority Priority { get; set; } 
        public string? Notes { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }


        #region Relation With Product
        public Guid ProductId { get; set; }// FK

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Product.Notifications))]
        public Product Product { get; set; } = null!; // Navigation Property
        #endregion
    }
}
