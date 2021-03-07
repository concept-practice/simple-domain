namespace SimpleDomain.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SimpleDomain.Core;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of a certain type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntities<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Retrieves all entities of a type from a collection.
        /// </summary>
        /// <returns>A Task of List of TEntities.</returns>
        Task<List<TEntity>> GetAllEntities();
    }
}
