using System;

namespace SimpleDomain.Validation
{
    /// <summary>
    /// Used to validate that reference objects are not null.
    /// </summary>
    public static class NullValidator
    {
        /// <summary>
        /// Validates that an object is not null.
        /// </summary>
        /// <param name="entity">The object to be validated.</param>
        public static void Validate([ValidatedNotNull] object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        /// <summary>
        /// Validates that an IEnumerable of objects is not null.
        /// </summary>
        /// <param name="entities">An IEnumerable of objects to be validated.</param>
        public static void ValidateParams([ValidatedNotNull] params object[] entities)
        {
            foreach (var entity in entities)
            {
                Validate(entity);
            }
        }

        /// <summary>
        /// Validates a GUID against null or empty values.
        /// </summary>
        /// <param name="id">The GUID to be validated.</param>
        public static void ValidateGuid([ValidatedNotNull] Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        /// <summary>
        /// Required for VisualStudio to realize that an entity has been validated.
        /// </summary>
        [AttributeUsage(AttributeTargets.All)]
        private sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}
