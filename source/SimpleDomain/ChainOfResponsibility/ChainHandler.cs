namespace SimpleDomain.ChainOfResponsibility
{
    using System.Threading.Tasks;

    public abstract class ChainHandler<T> : IChainHandler<T>
    {
        private readonly ChainHandler<T> _successor;

        protected ChainHandler(ChainHandler<T> successor)
        {
            _successor = successor;
        }

        public async Task<T> Handle(T request)
        {
            var result = await DoWork(request);

            return _successor == null ? result : await _successor.Handle(result);
        }

        protected abstract Task<T> DoWork(T request);
    }
}
