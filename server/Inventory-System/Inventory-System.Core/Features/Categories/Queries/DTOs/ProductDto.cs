using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderLevel { get; set; }
        public int MinStockLevel { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public string CreatedBy { get; set; }

        // Flattened from Category navigation property
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
