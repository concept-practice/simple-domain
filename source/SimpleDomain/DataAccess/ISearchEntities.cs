namespace SimpleDomain.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ISearchEntities<T>
    {
        Task<List<T>> SearchEntities(Expression<Func<T, bool>> baseQuery);
    }
}
