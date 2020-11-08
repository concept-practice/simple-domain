using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDomain.Tests.Core
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void EqualsOperator_ValidObjects_ReturnsTrue()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(1);

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        public void EqualsOperator_InvalidObjects_ReturnsFalse()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(2);

            var result = first == second;

            Assert.IsFalse(first == second);
        }

        [TestMethod]
        public void NotEqualsOperator_ValidObjects_ReturnsFalse()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(1);

            Assert.IsFalse(first != second);
        }

        [TestMethod]
        public void NotEqualsOperator_InValidObjects_ReturnsTrue()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(2);

            Assert.IsTrue(first != second);
        }

        [TestMethod]
        public void Equals_EqualValueObjects_ReturnsTrue()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(1);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_InvalidValueObjects_ReturnsFalse()
        {
            var first = new TestValueObject(1);

            var second = new TestValueObject(2);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_EqualObjects_ReturnsTrue()
        {
            var first = new TestValueObject(1);

            object second = new TestValueObject(1);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_InvalidObjects_ReturnsFalse()
        {
            var first = new TestValueObject(1);

            object second = new TestValueObject(2);

            Assert.IsFalse(first.Equals(second));
        }
    }
}
