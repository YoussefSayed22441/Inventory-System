using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Notifications = new HashSet<Notification>();
            ProductSuppliers = new HashSet<ProductSupplier>();
            StockHistories = new HashSet<StockHistory>();
        }
      
        public string ProductName { get; set; } 
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderLevel { get; set; }
        public int MinStockLevel { get; set; }
        public string? UnitOfMeasurement { get; set; }
   

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


        #region Relation With ProductSuppliers
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
        #endregion

        #region Relation With StockHistories
        public ICollection<StockHistory> StockHistories { get; set; } 
        #endregion

    }
}
