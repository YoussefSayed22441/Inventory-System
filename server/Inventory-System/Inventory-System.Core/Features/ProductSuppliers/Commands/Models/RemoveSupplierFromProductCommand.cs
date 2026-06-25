using Inventory_System.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Commands.Models
{
    public class RemoveSupplierFromProductCommand : IRequest<Result<bool>>
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }

        public RemoveSupplierFromProductCommand(Guid productId, Guid supplierId)
        {
            ProductId = productId;
            SupplierId = supplierId;
        }
    }
}
