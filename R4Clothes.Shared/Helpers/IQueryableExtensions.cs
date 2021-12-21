using R4Clothes.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagition)
        {
            return queryable
                .Skip((pagition.Page - 1) * pagition.QuantityPerPage)
                .Take(pagition.QuantityPerPage);
        }
    }
}
