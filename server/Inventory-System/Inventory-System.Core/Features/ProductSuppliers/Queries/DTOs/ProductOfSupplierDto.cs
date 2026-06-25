using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.DTOs
{
    public class ProductOfSupplierDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public decimal CostPrice { get; set; }
        public string CreatedBy { get; set; }

        public string ProductName { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal SellingPrice { get; set; }
        public int CurrentStock { get; set; }
        public string CategoryName { get; set; }

    }
}
