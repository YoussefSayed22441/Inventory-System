using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Features.Categories.Queries.Models;
using Inventory_System.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.Handles
{
    internal class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Result<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public GetSupplierByIdQueryHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        public async Task<Result<SupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierService.GetByIdAsync(request.Id);
            if(supplier == null)
            {
                return Result<SupplierDto>.Failure("SupplierNotFound", ResultStatus.NotFound);
            }
            var dto = _mapper.Map<SupplierDto>(supplier);
            return Result<SupplierDto>.Success(dto);
        }
    }
}
