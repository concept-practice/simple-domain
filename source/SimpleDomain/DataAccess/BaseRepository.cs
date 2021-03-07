namespace SimpleDomain.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SimpleDomain.Core;
    using SimpleDomain.Validation;

    public abstract class BaseRepository<T> :
        IAddEntity<T>,
        IAddEntities<T>,
        IGetById<T>,
        IGetAllEntities<T>,
        IUpdateEntity<T>,
        IDeleteEntity,
        ISearchEntities<T>
        where T : Entity
    {
        private readonly Func<IQueryable<T>, IQueryable<T>> _includeFunc;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        protected BaseRepository(DbContext context, Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        public DbContext Context { get; }

        public async Task AddEntity(T entity)
        {
            await Context.Set<T>().AddAsync(entity);

            await Context.SaveChangesAsync();
        }

        public async Task AddEntities(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);

            await Context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllEntities()
        {
            return await EntityContext()
                .ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await EntityContext()
                .FirstAsync(x => x.Id == id);
        }

        public async Task UpdateEntity(T entity)
        {
            Context.Update(entity);

            await Context.SaveChangesAsync();
        }

        public async Task<List<T>> SearchEntities(Expression<Func<T, bool>> baseQuery)
        {
            NullValidator.Validate(baseQuery);

            return await EntityContext()
                .Where(baseQuery)
                .ToListAsync();
        }

        public async Task DeleteEntity(Guid id)
        {
            var entity = await GetById(id);

            Context.Set<T>().Remove(entity);

            await Context.SaveChangesAsync();
        }

        private IQueryable<T> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<T>()) : Context.Set<T>();
        }
    }
}
