using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Service.Configuration
{
    public static class PagingHelper
    {
        public static IQueryable<TEntity> AutoPaging<TEntity>(this IQueryable<TEntity> query, int pagingSize, int pagingIndex)
        {
            if (pagingIndex <= 0)
            {
                return query;
            }
            return query.Skip((pagingIndex - 1) * pagingSize).Take(pagingSize);
        }
    }
    
}
