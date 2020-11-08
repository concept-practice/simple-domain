using SimpleDomain.Core;

namespace SimpleDomain.Factories
{
    /// <summary>
    /// Interface used to describe a class that instantiates and updated entity.
    /// </summary>
    /// <typeparam name="TRequest">The type of the update request.</typeparam>
    /// <typeparam name="TEntity">The type of the entity being updated.</typeparam>
    public interface IUpdateEntity<in TRequest, TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Returns a newly updated instance of an entity.
        /// </summary>
        /// <param name="request">The update request object.</param>
        /// <param name="entity">The entity object being updated.</param>
        /// <returns>An updated object of the entity.</returns>
        TEntity UpdatedEntity(TRequest request, TEntity entity);
    }
}
