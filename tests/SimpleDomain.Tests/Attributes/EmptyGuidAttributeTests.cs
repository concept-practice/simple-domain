namespace SimpleDomain.Tests.Attributes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleDomain.Attributes;

    [TestClass]
    public class EmptyGuidAttributeTests
    {
        private readonly EmptyGuidAttribute _attribute;

        public EmptyGuidAttributeTests()
        {
            _attribute = new EmptyGuidAttribute();
        }

        [TestMethod]
        public void IsValid_InvalidGuid_ReturnsFalse()
        {
            Assert.IsFalse(_attribute.IsValid(Guid.Empty));
        }

        [TestMethod]
        public void IsValid_ValidGuid_ReturnsTrue()
        {
            Assert.IsTrue(_attribute.IsValid(Guid.NewGuid()));
        }

        [TestMethod]
        public void IsValid_OnFailure_ReturnsCorrectErrorMessage()
        {
            _attribute.IsValid(Guid.Empty);

            Assert.AreEqual("Id may not be empty.", _attribute.ErrorMessage);
        }
    }
}
