namespace SimpleDomain.Contracts
{
    using System;
    using SimpleDomain.Validation;

    public abstract class EntityResponse
    {
        protected EntityResponse(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        public Guid Id { get; }
    }
}
