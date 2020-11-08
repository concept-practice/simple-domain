using System.Collections.Generic;
using SimpleDomain.Validation;

namespace SimpleDomain.Contracts
{
    /// <summary>
    /// A base class for retrieving all entities of a type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public abstract class AllEntitiesResponse<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllEntitiesResponse{TEntity}"/> class.
        /// </summary>
        /// <param name="entities">An IEnumerable of type TEntity.</param>
        protected AllEntitiesResponse(IEnumerable<TEntity> entities)
        {
            NullValidator.Validate(entities);

            Entities = entities;
        }

        /// <summary>
        /// Gets all entities of type TEntity.
        /// </summary>
        /// <value>An IEnumerable of type TEntity.</value>
        public IEnumerable<TEntity> Entities { get; }
    }
}
