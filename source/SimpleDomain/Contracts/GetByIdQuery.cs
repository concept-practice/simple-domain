namespace SimpleDomain.Contracts
{
    using System;
    using SimpleDomain.Validation;

    public abstract class GetByIdQuery<TQuery>
        where TQuery : class
    {
        protected GetByIdQuery(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        public Guid Id { get; }
    }
}
