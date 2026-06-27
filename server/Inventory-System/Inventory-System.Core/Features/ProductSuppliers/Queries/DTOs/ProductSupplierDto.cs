using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.DTOs
{
    public class ProductSupplierDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public decimal CostPrice { get; set; }
        public string CreatedBy { get; set; }

        public string ProductName { get; set; }
        public string SupplierName { get; set; }


    }
}
