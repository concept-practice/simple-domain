using System.Threading.Tasks;
using SimpleDomain.ChainOfResponsibility;

namespace SimpleDomain.Tests.ChainOfResponsibility
{
    public class TestChainHandler : ChainHandler<int>
    {
        public TestChainHandler(ChainHandler<int> successor)
            : base(successor)
        {
        }

        protected override Task<int> DoWork(int request)
        {
            return Task.FromResult(++request);
        }
    }
}
