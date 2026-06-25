using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Domain.Entities;
using Inventory_System.Service.Abstracts;
using MediatR;


namespace Inventory_System.Core.Features.ProductSuppliers.Commands.Handlers
{
    public class AssignSupplierToProductCommandHandler : IRequestHandler<AssignSupplierToProductCommand, Result<ProductSupplierDto>>
    {
        private readonly IProductSupplierService _productSupplierService;
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public AssignSupplierToProductCommandHandler(
            IProductSupplierService productSupplierService,
            IProductService productService,
            ISupplierService supplierService,
            IMapper mapper)
        {
            _productSupplierService = productSupplierService;
            _productService = productService;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Result<ProductSupplierDto>> Handle(AssignSupplierToProductCommand request, CancellationToken cancellationToken)
        {
            // Validate Product exists
            var productExists = await _productService.ExistsAsync(request.ProductId);
            if (!productExists)
                return Result<ProductSupplierDto>.Failure("Product Not Found", ResultStatus.NotFound);

            // Validate Supplier exists
            var supplierExists = await _supplierService.ExistsAsync(request.SupplierId);
            if (!supplierExists)
                return Result<ProductSupplierDto>.Failure("Supplier Not Found", ResultStatus.NotFound);

            var productSupplier = _mapper.Map<Inventory_System.Domain.Entities.ProductSupplier>(request);
            var result = await _productSupplierService.AssignAsync(productSupplier);

            if (result == null)
                return Result<ProductSupplierDto>.Failure("This supplier is already assigned to the product.", ResultStatus.ValidationError);

            
            var dto = _mapper.Map<ProductSupplierDto>(result);
            return Result<ProductSupplierDto>.Created(dto, "Supplier Assigned to Product Successfully");
        }
    }
}
