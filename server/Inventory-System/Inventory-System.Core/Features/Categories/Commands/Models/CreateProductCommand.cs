using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Models
{
    public class CreateProductCommand : IRequest<Result<ProductDto>>
    {
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
        public Guid CategoryId { get; set; }

        // Temporary default - replace with authenticated user once JWT/Auth is implemented
        public string CreatedBy { get; set; } = "System";
    }
}
