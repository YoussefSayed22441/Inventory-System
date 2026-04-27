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
    [Table("Notifications")]
    public class Notification : BaseEntity
    {
        #region Props
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public NotificationType Type { get; set; }
        [Required]
        public NotificationPriority Priority { get; set; } 
        public string? Notes { get; set; }
        public bool IsRead { get; set; } = false;
        #endregion

        #region Relation With Product
        // Foreign Key (nullable — general notifications may not link to a product)
        public Guid? ProductId { get; set; }// FK

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Product.Notifications))]
        public Product? Product { get; set; } = null!; // Navigation Property
        #endregion

    }

}


