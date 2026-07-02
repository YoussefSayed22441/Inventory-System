using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Queries.Models
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
