using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDomain.Tests.ChainOfResponsibility
{
    [TestClass]
    public class ChainHandlerTests
    {
        [TestMethod]
        public async Task ChainHandler_WithSuccessor_CallsSuccessorCorrectly()
        {
            var firstHandler = new TestChainHandler(new TestChainHandler(null));

            var result = await firstHandler.Handle(1);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public async Task ChainHandler_NoSuccessor_ReturnsCorrectly()
        {
            var firstHandler = new TestChainHandler(null);

            var result = await firstHandler.Handle(1);

            Assert.AreEqual(2, result);
        }
    }
}
