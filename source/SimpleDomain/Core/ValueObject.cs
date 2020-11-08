using System;
using System.Collections.Generic;
using System.Reflection;
using SimpleDomain.Validation;

namespace SimpleDomain.Core
{
    /// <summary>
    /// Base class for a value object to use value equality.
    /// </summary>
    /// <typeparam name="T">The type of the value object.</typeparam>
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// Implemented as best practice to the inheriting IEquatable interface.
        /// </summary>
        /// <param name="firstValueObject">The first valueObject to be compared against.</param>
        /// <param name="secondValueObject">The second valueObject to be compared against.</param>
        /// <returns>A boolean representing object equality.</returns>
        public static bool operator ==(ValueObject<T> firstValueObject, ValueObject<T> secondValueObject)
        {
            NullValidator.Validate(firstValueObject);

            return firstValueObject.Equals(secondValueObject);
        }

        /// <summary>
        /// Implemented as best practice to the inheriting IEquatable interface.
        /// </summary>
        /// <param name="firstValueObject">The first valueObject to be compared against.</param>
        /// <param name="secondValueObject">The second valueObject to be compared against.</param>
        /// <returns>A boolean representing object equality.</returns>
        public static bool operator !=(ValueObject<T> firstValueObject, ValueObject<T> secondValueObject)
        {
            return !(firstValueObject == secondValueObject);
        }

        /// <summary>
        /// Implemented as best practice to the inheriting IEquatable interface.
        /// </summary>
        /// <param name="obj">The value object to be compared against.</param>
        /// <returns>A boolean representing object equality.</returns>
        public override bool Equals(object obj)
        {
            NullValidator.Validate(obj);

            if (obj is T valueObject)
            {
                return Equals(valueObject);
            }

            return false;
        }

        /// <summary>
        /// Implemented as best practice due to inheriting IEquatable interface.
        /// </summary>
        /// <returns>The hashcode for the value object.</returns>
        public override int GetHashCode()
        {
            var fields = GetFields();

            const int startValue = 17;
            const int multiplier = 59;
            var hashCode = startValue;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);

                if (value != null)
                {
                    hashCode = hashCode * multiplier + value.GetHashCode();
                }
            }

            return hashCode;
        }

        /// <summary>
        /// Implemented from the IEquatable interface for value equality.
        /// </summary>
        /// <param name="other">A ValueObject to be compared against.</param>
        /// <returns>A boolean representing value equality.</returns>
        public virtual bool Equals(T other)
        {
            NullValidator.Validate(other);

            var t = GetType();
            var otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the fields from the value object.
        /// </summary>
        /// <returns>An IEnumerable of FieldInfo.</returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();
            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.BaseType;
            }

            return fields;
        }
    }
}
