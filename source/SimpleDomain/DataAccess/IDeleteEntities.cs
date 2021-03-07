namespace SimpleDomain.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SimpleDomain.Core;

    /// <summary>
    /// An interface used to describe a class that can remove multiple entities as once.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entities.</typeparam>
    public interface IDeleteEntities<in TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Removes multiple entities at one time.
        /// </summary>
        /// <param name="entities">The entities to be removed.</param>
        /// <returns>A Task object.</returns>
        Task DeleteEntities(IEnumerable<TEntity> entities);
    }
}
