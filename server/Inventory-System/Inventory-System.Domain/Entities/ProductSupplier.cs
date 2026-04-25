using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class ProductSupplier
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive value")]
        public decimal Cost { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

    }
}
