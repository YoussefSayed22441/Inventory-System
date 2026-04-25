using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            Notifications = new HashSet<Notification>();
        }
        [Key]
        public Guid ProductId { get; set; } // we want to use Guid for uniqueness
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? SKU { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Barcode { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal SellingPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive value")]
        public decimal CostPrice { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Current stock cannot be negative")]
        public int CurrentStock { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int MinStockLevel { get; set; }
        [MaxLength(50)]
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
        public ICollection<Notification>? Notifications { get; set; } // Navigation Property
        #endregion

        public ICollection<ProductSupplier>? ProductSuppliers { get; set; }
        public ICollection<StockHistory>? StockHistories { get; set; }
       
        /////////////////////////////////
        // don't forget the user relation
        /////////////////////////////////
    }
}
