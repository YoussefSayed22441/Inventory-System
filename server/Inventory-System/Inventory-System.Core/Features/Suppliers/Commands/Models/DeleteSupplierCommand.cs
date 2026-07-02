using Inventory_System.Core.Bases;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Commands.Models
{
    public class DeleteSupplierCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }

        public DeleteSupplierCommand(Guid id)
        {
            Id = id;
        }
    }
}
