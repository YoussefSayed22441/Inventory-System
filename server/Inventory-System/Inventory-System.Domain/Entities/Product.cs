using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        #region Constructors
        public Product()
        {
            Notifications = new HashSet<Notification>();
        }
        #endregion

        #region Props
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; } = string.Empty;
       
        [MaxLength(1000)]
        public string? Description { get; set; }
       
        [MaxLength(50)]
        public string? SKU { get; set; } = string.Empty;
       
        [MaxLength(50)]
        public string? Barcode { get; set; }
      
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal SellingPrice { get; set; }
      
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive value")]
        public decimal CostPrice { get; set; }
       
        [Range(0, int.MaxValue, ErrorMessage = "Current stock cannot be negative")]
        public int CurrentStock { get; set; } = 0;
       
        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; }
       
        [Range(0, int.MaxValue)]
        public int MinStockLevel { get; set; }
        
        [MaxLength(50)]
        public string? UnitOfMeasurement { get; set; }
        #endregion

        #region Relation With Category
        public Guid CategoryId { get; set; } // FK
        
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Entities.Category.Products))]
        public Category Category { get; set; } = null!;  // Navigation Property
        #endregion

        #region Relation With Notification
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>(); 
        #endregion

        #region Relation With ProductSuppliers
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
        #endregion

        #region Relation With StockHistories
        public ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
        #endregion

    }
}
