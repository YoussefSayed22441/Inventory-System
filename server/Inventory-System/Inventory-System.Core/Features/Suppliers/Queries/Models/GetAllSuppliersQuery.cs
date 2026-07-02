using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using Inventory_System.Core.Wrapper;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Queries.Models
{
    public class GetAllSuppliersQuery : IRequest<Result<PaginatedResult<SupplierDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
