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
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public decimal CostPrice { get; set; }

        #region Relation with Product
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Entities.Product.ProductSuppliers))]
        public Product Product { get; set; }
        #endregion

        #region Relation with Supplier
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Entities.Supplier.ProductSuppliers))]
        public Supplier Supplier { get; set; }
        #endregion
    }
}
