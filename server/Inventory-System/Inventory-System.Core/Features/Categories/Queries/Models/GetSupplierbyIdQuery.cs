using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.Models
{
    public class GetSupplierByIdQuery : IRequest<Result<SupplierDto>>
    {
        public Guid Id { get; set; }
        public GetSupplierByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
