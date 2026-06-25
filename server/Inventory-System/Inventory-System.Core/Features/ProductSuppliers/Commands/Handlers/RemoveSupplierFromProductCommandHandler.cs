using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSuppliers.Commands.Handlers
{
    public class RemoveSupplierFromProductCommandHandler : IRequestHandler<RemoveSupplierFromProductCommand, Result<bool>>
    {
        private readonly IProductSupplierService _productSupplierService;

        public RemoveSupplierFromProductCommandHandler(IProductSupplierService productSupplierService)
        {
            _productSupplierService = productSupplierService;
        }

        public async Task<Result<bool>> Handle(RemoveSupplierFromProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _productSupplierService.GetByIdsAsync(request.ProductId, request.SupplierId);
            if(existing == null)
                return Result<bool>.Failure("Product-Supplier Link Not Found", ResultStatus.NotFound);
            
            var result = await _productSupplierService.RemoveAsync(existing);
            if(!result)
                return Result<bool>.Failure("Remove Supplier from Product Failed", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "Supplier Removed from Product Successfully");
        }
    }
}
