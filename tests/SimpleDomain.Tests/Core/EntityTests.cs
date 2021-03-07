namespace SimpleDomain.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void EqualsOperator_SameEntity_ReturnsTrue()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = first;

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        public void EqualsOperator_DifferentEntity_ReturnsFalse()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = new TestEntity(Guid.NewGuid());

            Assert.IsFalse(first == second);
        }

        [TestMethod]
        public void NotEqualsOperator_SameEntity_ReturnsFalse()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = first;

            Assert.IsFalse(first != second);
        }

        [TestMethod]
        public void NotEqualsOperator_DifferentEntity_ReturnsFalse()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = new TestEntity(Guid.NewGuid());

            Assert.IsTrue(first != second);
        }

        [TestMethod]
        public void Equals_SameEntity_ReturnsTrue()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = first;

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_DifferentEntity_ReturnsFalse()
        {
            var first = new TestEntity(Guid.NewGuid());

            var second = new TestEntity(Guid.NewGuid());

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            var first = new TestEntity(Guid.NewGuid());

            object second = first;

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_DifferentObjects_ReturnsFalse()
        {
            var first = new TestEntity(Guid.NewGuid());

            object second = new TestEntity(Guid.NewGuid());

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void GetHashCode_ReturnsCorrectHashCode()
        {
            var id = Guid.NewGuid();

            var entity = new TestEntity(id);

            Assert.AreEqual(id.GetHashCode(), entity.GetHashCode());
        }
    }
}
