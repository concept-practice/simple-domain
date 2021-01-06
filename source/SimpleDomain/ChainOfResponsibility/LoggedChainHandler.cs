using System;
using System.Threading.Tasks;
using Serilog;

namespace SimpleDomain.ChainOfResponsibility
{
    public abstract class LoggedChainHandler<T> : IChainHandler<T>
    {
        private readonly IChainHandler<T> _successor;
        private readonly ILogger _logger;

        protected LoggedChainHandler(IChainHandler<T> successor, ILogger logger)
        {
            _successor = successor;
            _logger = logger;
        }

        public async Task<T> Handle(T request)
        {
            _logger.Information($"Attempting to do {nameof(request)}.");

            T result = default;

            try
            {
                result = await DoWork(request);

                _logger.Information($"Request for {nameof(request)} complete.");
            }
            catch (Exception exception)
            {
                _logger.Error($"We had a boo boo at {exception.Message}.");
            }

            return _successor == null ? result : await _successor.Handle(result);
        }

        protected abstract Task<T> DoWork(T request);
    }
}
