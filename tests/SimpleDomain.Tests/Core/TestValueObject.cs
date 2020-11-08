using SimpleDomain.Core;

namespace SimpleDomain.Tests.Core
{
    public class TestValueObject : ValueObject<TestValueObject>
    {
        public TestValueObject(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
