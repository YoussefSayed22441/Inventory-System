using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Commands.Models;
using Inventory_System.Service.Abstracts;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Commands.Handlers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Result<bool>>
    {
        private readonly ISupplierService _supplierService;

        public DeleteSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<Result<bool>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierService.GetByIdAsync(request.Id);
            if (supplier == null) return Result<bool>.Failure("Supplier Not Found", ResultStatus.NotFound);

            var result = await _supplierService.DeleteAsync(supplier);
            if (!result) return Result<bool>.Failure("Supplier Delete Failed", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "Supplier Deleted Successfully");
        }
    }
}
