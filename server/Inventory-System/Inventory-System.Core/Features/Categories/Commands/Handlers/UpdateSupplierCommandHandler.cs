using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Result<SupplierDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierService.GetByIdAsync(request.Id);

            if (existingSupplier == null)
                return Result<SupplierDto>.Failure("Supplier Not Found", ResultStatus.NotFound);
        
            _mapper.Map(request, existingSupplier);

            var result = await _supplierService.UpdateAsync(existingSupplier);
            if(result == null)
                return Result<SupplierDto>.Failure("Supplier Update Failed", ResultStatus.ValidationError);

            var dto = _mapper.Map<SupplierDto>(result);
            return Result<SupplierDto>.Success(dto, "Supplier Updated Successfully");
        }
    }
}
