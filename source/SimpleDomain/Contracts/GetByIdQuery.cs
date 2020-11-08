using System;
using SimpleDomain.Validation;

namespace SimpleDomain.Contracts
{
    /// <summary>
    /// A base class for a retrieve by Id query.
    /// </summary>
    /// <typeparam name="TQuery">The type of the entity to be retrieved.</typeparam>
    public abstract class GetByIdQuery<TQuery>
        where TQuery : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIdQuery{TQuery}"/> class.
        /// </summary>
        /// <param name="id">The Id of the entity to be retrieved.</param>
        protected GetByIdQuery(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        /// <summary>
        /// Gets the Id for the entity.
        /// </summary>
        /// <value>A GUID.</value>
        public Guid Id { get; }
    }
}
