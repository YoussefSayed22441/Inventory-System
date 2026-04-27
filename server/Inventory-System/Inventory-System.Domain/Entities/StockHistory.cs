using Inventory_System.Domain.Entities.Base;
using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("StockHistories")]
    public class StockHistory :BaseEntity
    {
        #region Props
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid? SupplierId { get; set; }

        [Required]
        public TransactionType Type { get; set; } 
       
        [MaxLength(500)]
        public string? Notes { get; set; }
        #endregion

        #region Relation with Product
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } // Navigation
        #endregion

        #region Relation with Supplier
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }
        #endregion

    }
}
