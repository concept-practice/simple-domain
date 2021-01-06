using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace SimpleDomain.Handlers
{
    public abstract class LoggedRequestHandler<TIn, TOut> : IRequestHandler<TIn, TOut>
        where TIn : IRequest<TOut>
    {
        private readonly ILogger _logger;

        protected LoggedRequestHandler(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
        {
            _logger.Information($"Attempting to do {nameof(request)}.");

            try
            {
                var result = await DoWork(request, cancellationToken);

                _logger.Information($"Request for {nameof(request)} complete.");

                return result;
            }
            catch (Exception exception)
            {
                _logger.Error($"We had a boo boo at {exception.Message}.");

                return default;
            }
        }

        protected abstract Task<TOut> DoWork(TIn request, CancellationToken cancellationToken);
    }
}
