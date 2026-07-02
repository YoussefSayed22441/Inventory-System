using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Suppliers.Commands.Models;
using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using Inventory_System.Domain.Entities;
using Inventory_System.Service.Abstracts;
using MediatR;

namespace Inventory_System.Core.Features.Suppliers.Commands.Handlers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Result<SupplierDto>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request);
            var result = await _supplierService.AddAsync(supplier);

            if (result == null) return Result<SupplierDto>.Failure("Supplier with this email already exists.", ResultStatus.ValidationError);

            var dto = _mapper.Map<SupplierDto>(result);
            return Result<SupplierDto>.Created(dto, "Supplier Created Successfully");
        }
    }
}
