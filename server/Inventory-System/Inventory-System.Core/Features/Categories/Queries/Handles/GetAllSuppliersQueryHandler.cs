using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Features.Categories.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Inventory_System.Core.Features.Categories.Queries.Handles
{
    internal class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, Result<PaginatedResult<SupplierDto>>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<SupplierDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var query = _supplierService.GetSuppliers();
            var totalCount = await query.CountAsync();

            var data = query
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<SupplierDto>
                .Success(data, request.PageNumber, totalCount, request.PageSize);

            return Result<PaginatedResult<SupplierDto>>.Success(paginated);
        }
    }
}
