namespace SimpleDomain.Tests.ChainOfResponsibility
{
    using System.Threading.Tasks;
    using SimpleDomain.ChainOfResponsibility;

    public class TestChainHandler : ChainHandler<int>
    {
        public TestChainHandler(IChainHandler<int> successor)
            : base(successor)
        {
        }

        protected override Task<int> DoWork(int request)
        {
            return Task.FromResult(++request);
        }
    }
}
