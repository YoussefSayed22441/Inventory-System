using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class ProductSupplier : BaseEntity
    {
        #region Props
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
       
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive value")]
        public decimal Cost { get; set; }
        #endregion

        #region Realtion with Product
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        #endregion

        #region Realtion with Supplier
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        #endregion

    }
}
