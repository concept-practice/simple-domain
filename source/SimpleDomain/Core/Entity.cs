using System;
using SimpleDomain.Validation;

namespace SimpleDomain.Core
{
    /// <summary>
    /// A base class for an entity object with a GUID.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">A GUID that will represent the entity.</param>
        protected Entity(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        /// <summary>
        /// Gets or sets the Id for the entity.
        /// </summary>
        /// <value>A GUID.</value>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Implemented from the IEquatable interface. Does reference type equality check.
        /// </summary>
        /// <param name="other">An Entity object to be compared against.</param>
        /// <returns>A boolean representing object equality.</returns>
        public bool Equals(Entity other)
        {
            return other != null && other.Id.Equals(Id);
        }

        /// <summary>
        /// Implemented as best practice to the inheriting IEquatable interface.
        /// </summary>
        /// <param name="obj">An object to be compared against.</param>
        /// <returns>A boolean representing object equality.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Entity entity)
            {
                return Equals(entity);
            }

            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            // ReSharper doesn't realize it's a pass to force type checking.
            return base.Equals(obj);
        }

        /// <summary>
        /// Implemented as best practice due to inheriting IEquatable interface.
        /// </summary>
        /// <returns>The hashcode for the object.</returns>
        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            // Protected set is required for EF reflection.
            return Id.GetHashCode();
        }
    }
}
