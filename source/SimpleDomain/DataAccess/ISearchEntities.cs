using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleDomain.DataAccess
{
    public interface ISearchEntities<T>
    {
        Task<List<T>> SearchEntities(Expression<Func<T, bool>> baseQuery);
    }
}
