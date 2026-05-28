using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.Models
{
    public class GetProductsByCategoryQuery : IRequest<Result<PaginatedResult<ProductDto>>>
    {
        public Guid CategoryId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public GetProductsByCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
