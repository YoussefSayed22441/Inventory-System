using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSuppliers.Commands.Handlers
{
    public class UpdateSupplierCostPriceCommandHandler : IRequestHandler<UpdateSupplierCostPriceCommand, Result<ProductSupplierDto>>
    {
        private readonly IProductSupplierService _productSupplierService;
        private readonly IMapper _mapper;

        public UpdateSupplierCostPriceCommandHandler(IProductSupplierService productSupplierService, IMapper mapper)
        {
            _productSupplierService = productSupplierService;
            _mapper = mapper;
        }

        public async Task<Result<ProductSupplierDto>> Handle(UpdateSupplierCostPriceCommand request, CancellationToken cancellationToken)
        {
            var existing = await _productSupplierService.GetByIdsAsync(request.ProductId, request.SupplierId);
            if (existing == null)
                return Result<ProductSupplierDto>.Failure("Product-Supplier link Not Found", ResultStatus.NotFound);
            
            existing.CostPrice = request.NewCostPrice;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _productSupplierService.UpdateCostPriceAsync(existing);
            if(result == null)
                return Result<ProductSupplierDto>.Failure("Cost Price Update Failed", ResultStatus.ValidationError);

            var dto = _mapper.Map<ProductSupplierDto>(result);
            return Result<ProductSupplierDto>.Success(dto, "Cost Price Updated Successfully");

        }
    }
}
