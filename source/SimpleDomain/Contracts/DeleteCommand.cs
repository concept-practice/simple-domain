namespace SimpleDomain.Contracts
{
    using System;
    using SimpleDomain.Validation;

    public abstract class DeleteCommand
    {
        protected DeleteCommand(Guid id)
        {
            NullValidator.ValidateGuid(id);

            Id = id;
        }

        public Guid Id { get; }
    }
}
