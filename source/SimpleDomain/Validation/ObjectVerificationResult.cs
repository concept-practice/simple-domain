using System.Collections.Generic;

namespace SimpleDomain.Validation
{
    /// <summary>
    /// Used to represent either the success or failure of an object validation.
    /// </summary>
    public class ObjectVerificationResult
    {
        private ObjectVerificationResult(bool failed, IEnumerable<string> errors)
        {
            Failed = failed;
            Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the validation failed.
        /// </summary>
        /// <value>A boolean.</value>
        public bool Failed { get; }

        /// <summary>
        /// Gets a list of errors, if any.
        /// </summary>
        /// <value>An IEnumerable of string errors.</value>
        public IEnumerable<string> Errors { get; }

        /// <summary>
        /// Method to designate a successful validation.
        /// </summary>
        /// <returns>A successful validation result.</returns>
        public static ObjectVerificationResult Successful()
        {
            return new ObjectVerificationResult(false, null);
        }

        /// <summary>
        /// Method to designate a failed validation.
        /// </summary>
        /// <param name="errors">An IEnumerable of strings containing all validation errors.</param>
        /// <returns>A failed validation result.</returns>
        public static ObjectVerificationResult Failure(IEnumerable<string> errors)
        {
            return new ObjectVerificationResult(true, errors);
        }
    }
}
