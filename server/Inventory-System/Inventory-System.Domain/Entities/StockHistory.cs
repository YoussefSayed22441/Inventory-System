using Inventory_System.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("StockHistories")]
    public class StockHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public StockMovementType Type { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        #region Relation with Product
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; } // Navigation
        #endregion


        /////////////////////////////////
        // don't forget the user relation
        /////////////////////////////////
    }
}
