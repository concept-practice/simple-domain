using System.ComponentModel.DataAnnotations;

namespace SimpleDomain.Attributes
{
    /// <summary>
    /// Attribute used to validate if a string is null or empty.
    /// </summary>
    public sealed class RequiredStringAttribute : ValidationAttribute
    {
        /// <summary>
        /// Method to validate a string against null or empty.
        /// </summary>
        /// <param name="value">The string being validated.</param>
        /// <returns>A boolean indicating whether the validation succeeded.</returns>
        public override bool IsValid(object value)
        {
            return !string.IsNullOrEmpty((string)value);
        }
    }
}
