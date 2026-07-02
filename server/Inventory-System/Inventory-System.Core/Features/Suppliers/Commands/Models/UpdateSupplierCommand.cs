using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Commands.Models
{
    public class UpdateSupplierCommand : IRequest<Result<SupplierDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
