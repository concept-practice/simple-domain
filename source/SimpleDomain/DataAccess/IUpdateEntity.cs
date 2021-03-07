namespace SimpleDomain.DataAccess
{
    using System.Threading.Tasks;
    using SimpleDomain.Core;

    /// <summary>
    /// An interface used to describe a class that can update an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateEntity<in TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">A new version of the entity.</param>
        /// <returns>A Task object.</returns>
        Task UpdateEntity(TEntity entity);
    }
}
