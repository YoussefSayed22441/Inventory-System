using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Notifications = new HashSet<Notification>();
        }
        public Guid ProductId { get; set; } // we want to use Guid for uniqueness
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public string? SKU { get; set; } 
        public string? Barcode { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderLevel { get; set; }
        public int MinStockLevel { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        #region Relation With Category
        public Guid CategoryId { get; set; } // FK
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Entities.Category.Products))]
        public Category Category { get; set; } = null!;  // Navigation Property
        #endregion

        #region Relation With Notification
        [InverseProperty(nameof(Notification.Product))]
        public ICollection<Notification> Notifications { get; set; } // Navigation Property
        #endregion

    }
}
