using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }// we want to use Guid for uniqueness
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public NotificationType Type { get; set; } 
        public NotificationPriority Priority { get; set; } 
        public string? Notes { get; set; }
        public bool IsRead { get; set; } = false;
        [Required]
        public DateTime CreatedAt { get; set; }


        #region Relation With Product
        // Foreign Key (nullable — general notifications may not link to a product)
        public Guid? ProductId { get; set; }// FK

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Product.Notifications))]
        public Product? Product { get; set; } = null!; // Navigation Property
        #endregion

        /////////////////////////////////
        // don't forget the user relation
        /////////////////////////////////
    }
}
