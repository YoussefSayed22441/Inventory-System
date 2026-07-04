using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Products.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Products.Queries.Models
{
    public class GetProductByIdQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
