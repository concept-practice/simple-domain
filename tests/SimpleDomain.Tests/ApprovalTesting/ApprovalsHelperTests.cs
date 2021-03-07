namespace SimpleDomain.Tests.ApprovalTesting
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleDomain.ApprovalTesting;

    [TestClass]
    public class ApprovalsHelperTests
    {
        internal class ObjectToStringTest
        {
            public string Name { get; set; } = "Name";

            public int Age { get; set; } = 1;
        }

        [TestMethod]
        public void ObjectToString_Object_ReturnsCorrectString()
        {
            var objectToStringTest = new ObjectToStringTest();

            var result = ApprovalsHelper.ApprovalsString(objectToStringTest);

            var expected = $"Name: {objectToStringTest.Name}\n" +
                           $"Age: {objectToStringTest.Age}\n";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ObjectToString_IEnumerableObject_ReturnsCorrectString()
        {
            var objectToStringTestList = new List<ObjectToStringTest> { new ObjectToStringTest(), new ObjectToStringTest() };

            var result = ApprovalsHelper.ApprovalsString(objectToStringTestList)
                .Aggregate(string.Empty, (final, next) => final + next);

            var expected = $"Name: {objectToStringTestList[0].Name}\n" +
                           $"Age: {objectToStringTestList[0].Age}\n" +
                           $"Name: {objectToStringTestList[1].Name}\n" +
                           $"Age: {objectToStringTestList[1].Age}\n";

            Assert.AreEqual(expected, result);
        }
    }
}
