using System;
using SimpleDomain.Validation;

namespace SimpleDomain.Contracts
{
    /// <summary>
    /// A base class for entity responses with GUIDs.
    /// </summary>
    public abstract class EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityResponse"/> class.
        /// </summary>
        /// <param name="id">The GUID for the entity.</param>
        protected EntityResponse(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        /// <summary>
        /// Gets the ID for the entity.
        /// </summary>
        /// <value>A GUID.</value>
        public Guid Id { get; }
    }
}
