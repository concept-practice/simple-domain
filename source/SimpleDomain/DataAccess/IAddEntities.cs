using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDomain.Core;

namespace SimpleDomain.DataAccess
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entities.</typeparam>
    public interface IAddEntities<in TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Adds multiples entities to a collection.
        /// </summary>
        /// <param name="entities">An IEnumerable of the entities to be added.</param>
        /// <returns>A Task object.</returns>
        Task AddEntities(IEnumerable<TEntity> entities);
    }
}
