using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Suppliers")]
    public class Supplier : BaseEntity
    {
        #region Props
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        
        [MaxLength(20)]
        [Phone]
        public string? Phone { get; set; }
        
        [MaxLength(500)]
        public string? Address { get; set; }
        #endregion

        #region Relation with ProductSuppliers
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
        #endregion

        #region Relation with StockHistories 
        public ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
        #endregion
    }
}
