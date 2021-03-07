namespace SimpleDomain.DataAccess
{
    using System.Threading.Tasks;
    using SimpleDomain.Core;

    /// <summary>
    /// An interface that allows a class to add a single entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntity<in TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Adds a single entity to a collection.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A Task object.</returns>
        Task AddEntity(TEntity entity);
    }
}
