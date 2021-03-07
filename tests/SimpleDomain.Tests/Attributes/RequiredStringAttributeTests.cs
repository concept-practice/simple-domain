namespace SimpleDomain.Tests.Attributes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleDomain.Attributes;

    [TestClass]
    public class RequiredStringAttributeTests
    {
        private readonly RequiredStringAttribute _attribute;

        public RequiredStringAttributeTests()
        {
            _attribute = new RequiredStringAttribute();
        }

        [TestMethod]
        public void IsValid_ValidString_ReturnsTrue()
        {
            Assert.IsTrue(_attribute.IsValid("validString"));
        }

        [TestMethod]
        public void IsValid_EmptyString_ReturnsFalse()
        {
            Assert.IsFalse(_attribute.IsValid(string.Empty));
        }

        [TestMethod]
        public void IsValid_NullString_ReturnsFalse()
        {
            Assert.IsFalse(_attribute.IsValid(null));
        }
    }
}
