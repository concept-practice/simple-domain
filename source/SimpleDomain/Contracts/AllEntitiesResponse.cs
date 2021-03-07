namespace SimpleDomain.Contracts
{
    using System.Collections.Generic;
    using SimpleDomain.Validation;

    public abstract class AllEntitiesResponse<TEntity>
    {
        protected AllEntitiesResponse(IEnumerable<TEntity> entities)
        {
            NullValidator.Validate(entities);

            Entities = entities;
        }

        public IEnumerable<TEntity> Entities { get; }
    }
}
