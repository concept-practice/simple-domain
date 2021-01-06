using System;
using System.Threading.Tasks;
using Serilog;

namespace SimpleDomain.Strategy
{
    public abstract class LoggedStrategy<TIn, TOut> : IStrategy<TIn, TOut>
    {
        private readonly ILogger _logger;

        protected LoggedStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TOut> Handle(TIn request)
        {
            _logger.Information($"Attempting to do {nameof(request)}.");

            try
            {
                var result = await DoWork(request);

                _logger.Information($"Request for {nameof(request)} complete.");

                return result;
            }
            catch (Exception exception)
            {
                _logger.Error($"We had a boo boo at {exception.Message}.");

                return default;
            }
        }

        protected abstract Task<TOut> DoWork(TIn request);
    }
}
