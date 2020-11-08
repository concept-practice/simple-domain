using System;
using SimpleDomain.Validation;

namespace SimpleDomain.Contracts
{
    /// <summary>
    /// A base class for an update command.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to be updated.</typeparam>
    public abstract class UpdateEntityCommand<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEntityCommand{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The Id of entity to be updated.</param>
        /// <param name="entity">A instance of the updated entity.</param>
        protected UpdateEntityCommand(Guid id, TEntity entity)
        {
            NullValidator.ValidateParams(id, entity);

            Id = id;
            Entity = entity;
        }

        /// <summary>
        /// Gets the Id for the entity to be updated.
        /// </summary>
        /// <value>A GUID.</value>
        public Guid Id { get; }

        /// <summary>
        /// Gets the Entity to be updated.
        /// </summary>
        /// <value>An object of type TEntity.</value>
        public TEntity Entity { get; }
    }
}
