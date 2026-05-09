using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Wrapper
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public PaginatedResult(bool succeeded, List<T> data, int page, int count, int pageSize)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public static PaginatedResult<T> Success(List<T> data, int page, int count, int pageSize)
        {
            return new PaginatedResult<T>(true, data, page, count, pageSize);
        }

        public bool Succeeded { get; set; }
        public List<T> Data { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public object Meta { get; set; }
    }
}
