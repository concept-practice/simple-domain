namespace SimpleDomain.Core
{
    using System;
    using SimpleDomain.Validation;

    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        public Guid Id { get; protected set; }

        public bool Equals(Entity other)
        {
            return other != null && other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Entity entity)
            {
                return Equals(entity);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
