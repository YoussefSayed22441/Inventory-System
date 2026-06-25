using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.ProductSupplier.Queries.DTOs;
using Inventory_System.Core.Features.ProductSupplier.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.Handlers
{
    public class GetSuppliersByProductQueryHandler : IRequestHandler<GetSuppliersByProductQuery, Result<PaginatedResult<SupplierOfProductDto>>>
    {
        private readonly IProductSupplierService _productSupplierService;
        private readonly IMapper _mapper;

        public GetSuppliersByProductQueryHandler(IProductSupplierService productSupplierService, IMapper mapper)
        {
            _productSupplierService = productSupplierService;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<SupplierOfProductDto>>> Handle(GetSuppliersByProductQuery request, CancellationToken cancellationToken)
        {
            var query = _productSupplierService.GetSuppliersByProductId(request.ProductId);
            var totalCount = await query.CountAsync();

            var data = query
                .ProjectTo<SupplierOfProductDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<SupplierOfProductDto>
                .Success(data, request.PageNumber, totalCount, request.PageSize);

            return Result<PaginatedResult<SupplierOfProductDto>>.Success(paginated);
        }
    }
}
