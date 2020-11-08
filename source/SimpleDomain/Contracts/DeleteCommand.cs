using System;
using SimpleDomain.Validation;

namespace SimpleDomain.Contracts
{
    /// <summary>
    /// A base class for delete commands.
    /// </summary>
    public abstract class DeleteCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCommand"/> class.
        /// </summary>
        /// <param name="id">A GUID for the entity to be deleted.</param>
        protected DeleteCommand(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        /// <summary>
        /// Gets the Id for the entity to be deleted.
        /// </summary>
        /// <value>A GUID.</value>
        public Guid Id { get; }
    }
}
