using Inventory_System.Domain.Entities.Base;
using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class StockHistory :BaseEntity
    {
        public int Quantity { get; set; }
        public TransactionType Type { get; set; } 
        public string? Notes { get; set; }


        #region Relation with Product
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } // Navigation property
        #endregion

        #region Relation with Supplier
        public Guid? SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; } // Navigation property
        #endregion

    }
}
