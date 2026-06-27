using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Core.Features.StockHistories.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Inventory_System.Core.Features.StockHistories.Queries.Handlers
{
    public class GetAllStockHistoriesQueryHandler
        : IRequestHandler<GetAllStockHistoriesQuery, Result<PaginatedResult<StockHistoryDto>>>
    {
        private readonly IStockHistoryService _stockHistoryService;
        private readonly IMapper _mapper;

        public GetAllStockHistoriesQueryHandler(IStockHistoryService stockHistoryService, IMapper mapper)
        {
            _stockHistoryService = stockHistoryService;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<StockHistoryDto>>> Handle(
            GetAllStockHistoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _stockHistoryService.GetStockHistories(
                request.ProductId,
                request.SupplierId,
                request.Type,
                request.FromDate,
                request.ToDate);

            var totalCount = await query.CountAsync(cancellationToken);

            var data = query
                .ProjectTo<StockHistoryDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<StockHistoryDto>
                .Success(data, request.PageNumber, totalCount, request.PageSize);

            return Result<PaginatedResult<StockHistoryDto>>.Success(paginated);
        }
    }
}