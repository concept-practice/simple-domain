namespace SimpleDomain.DataAccess
{
    using System;
    using System.Threading.Tasks;
    using SimpleDomain.Core;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by GUID.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetById<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Retrieves an entity from a collection by its' GUID.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>An object of type TEntity.</returns>
        Task<TEntity> GetById(Guid id);
    }
}
