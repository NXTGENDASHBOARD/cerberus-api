using Cerberus.Dashboard.Application.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PaginationViewModel<TModel>> PaginationAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit,
            CancellationToken cancellationToken
            ) where TModel : class
        {

            var paged = new PaginationViewModel<TModel>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;

            paged.PageSize = limit;

            var totalItemsAsync = query.CountAsync(cancellationToken);

            var startRow = (page - 1) * limit;

            paged.Items = await query.Skip(startRow).Take(limit).ToListAsync(cancellationToken);

            paged.TotalItems = await totalItemsAsync;

            paged.TotalPages =  (int)Math.Ceiling(paged.TotalItems / (double)limit);


            return paged;

        }
    }
}
