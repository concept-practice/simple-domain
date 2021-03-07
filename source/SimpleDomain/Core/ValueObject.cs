namespace SimpleDomain.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using SimpleDomain.Validation;

    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public static bool operator ==(ValueObject<T> firstValueObject, ValueObject<T> secondValueObject)
        {
            NullValidator.Validate(firstValueObject);

            return firstValueObject.Equals(secondValueObject);
        }

        public static bool operator !=(ValueObject<T> firstValueObject, ValueObject<T> secondValueObject)
        {
            return !(firstValueObject == secondValueObject);
        }

        public override bool Equals(object obj)
        {
            NullValidator.Validate(obj);

            if (obj is T valueObject)
            {
                return Equals(valueObject);
            }

            return false;
        }

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
                    hashCode = (hashCode * multiplier) + value.GetHashCode();
                }
            }

            return hashCode;
        }

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
