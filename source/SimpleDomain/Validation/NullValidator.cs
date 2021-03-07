namespace SimpleDomain.Validation
{
    using System;

    public static class NullValidator
    {
        public static void Validate([ValidatedNotNull] object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public static void ValidateParams([ValidatedNotNull] params object[] entities)
        {
            foreach (var entity in entities)
            {
                Validate(entity);
            }
        }

        public static void ValidateGuid([ValidatedNotNull] Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        [AttributeUsage(AttributeTargets.All)]
        private sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}
