namespace SimpleDomain.Tests.Core
{
    using SimpleDomain.Core;

    public class TestValueObject : ValueObject<TestValueObject>
    {
        public TestValueObject(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
