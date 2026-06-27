using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.Models
{
    public class GetProductsBySupplierQuery : IRequest<Result<PaginatedResult<ProductOfSupplierDto>>>
    {
        public Guid SupplierId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public GetProductsBySupplierQuery(Guid supplierId)
        {
            SupplierId = supplierId;
        }
    }
}
