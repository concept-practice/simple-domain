namespace SimpleDomain.Tests.Validation
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleDomain.Validation;

    [TestClass]
    public class NullValidatorTests
    {
        [TestMethod]
        public void Validate_NullObject_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => NullValidator.Validate(default));
        }

        [TestMethod]
        public void Validate_ValidObjects_DoesNotThrowArgumentNullException()
        {
            NullValidator.Validate(string.Empty);
        }

        [TestMethod]
        public void Validate_NullParams_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => NullValidator.ValidateParams(string.Empty, default));
        }

        [TestMethod]
        public void Validate_ValidParams_DoesNotThrowArgumentNullException()
        {
            NullValidator.ValidateParams(string.Empty, string.Empty);
        }
    }
}
