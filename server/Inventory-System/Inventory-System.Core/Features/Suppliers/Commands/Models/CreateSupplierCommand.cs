using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Commands.Models
{
    public class CreateSupplierCommand : IRequest<Result<SupplierDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Temporary default — replace with authenticated user once JWT/Auth is implemented
        public string CreatedBy { get; set; } = "System";
    }
}
