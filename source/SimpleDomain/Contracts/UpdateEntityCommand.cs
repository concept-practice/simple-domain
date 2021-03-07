namespace SimpleDomain.Contracts
{
    using System;
    using SimpleDomain.Validation;

    public abstract class UpdateEntityCommand<TEntity>
    {
        protected UpdateEntityCommand(Guid id, TEntity entity)
        {
            NullValidator.ValidateParams(id, entity);

            Id = id;
            Entity = entity;
        }

        public Guid Id { get; }

        public TEntity Entity { get; }
    }
}
