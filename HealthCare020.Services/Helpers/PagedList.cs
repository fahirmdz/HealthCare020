using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthCare020.Services.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumer, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumer;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip(((pageNumber<1?1:pageNumber)- 1) * pageSize);

            if (pageSize <= items.Count())
                items = items.Take(pageSize);

            return new PagedList<T>(items.ToList(), count, pageNumber, pageSize);
        }
    }
}