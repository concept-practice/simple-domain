namespace SimpleDomain.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class EmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((Guid)value != Guid.Empty)
            {
                return true;
            }

            ErrorMessage = "Id may not be empty.";
            return false;
        }
    }
}
