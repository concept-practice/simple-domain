using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleDomain.Attributes
{
    /// <summary>
    /// An attribute class for validating GUIDs.
    /// </summary>
    public sealed class EmptyGuidAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates a GUID against null or empty values.
        /// </summary>
        /// <param name="value">The GUID to be validated.</param>
        /// <returns>A boolean representing the validation result.</returns>
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
