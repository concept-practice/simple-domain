using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDomain.Utilities;

namespace SimpleDomain.Tests.Utilities
{
    [TestClass]
    public class StringUtilitiesTests
    {
        [TestMethod]
        public void ParseToTimeSpan_String_ConvertsCorrectly()
        {
            var minValue = TimeSpan.MinValue;

            var result = minValue.ToString().ParseToTimeSpan();

            Assert.AreEqual(minValue, result);
        }

        [TestMethod]
        public void ToStringInvariant_Double_ConvertsCorrectly()
        {
            const double value = 3.0;

            Assert.AreEqual("3", value.ToStringInvariant());
        }
    }
}
