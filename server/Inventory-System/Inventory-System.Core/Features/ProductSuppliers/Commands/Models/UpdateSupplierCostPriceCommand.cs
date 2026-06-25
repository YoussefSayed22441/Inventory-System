using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Commands.Models
{
    public class UpdateSupplierCostPriceCommand : IRequest<Result<ProductSupplierDto>>
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public decimal NewCostPrice { get; set; }
    }
}
