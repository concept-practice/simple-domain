using System.Threading.Tasks;

namespace SimpleDomain.ChainOfResponsibility
{
    /// <summary>
    /// A base class for chain of responsibility handlers.
    /// </summary>
    /// <typeparam name="T">The type of the request object being passed down the chain.</typeparam>
    public abstract class ChainHandler<T> : IChainHandler<T>
    {
        /// <summary>
        /// An instance for the successor handler. Possibly null.
        /// </summary>
        private readonly ChainHandler<T> _successor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainHandler{T}"/> class.
        /// </summary>
        /// <param name="successor">The successor for a chain handler. Possibly null.</param>
        protected ChainHandler(ChainHandler<T> successor)
        {
            _successor = successor;
        }

        /// <summary>
        /// Checks if a successor exists, and either returns the request after handling it, or passes it down the chain.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <returns>A <see cref="Task{T}"/>.</returns>
        public async Task<T> Handle(T request)
        {
            return _successor == null ? await DoWork(request) : await _successor.Handle(await DoWork(request));
        }

        /// <summary>
        /// Method implemented by derived classes to handle a request.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <returns>A <see cref="Task{T}"/>.</returns>
        protected abstract Task<T> DoWork(T request);
    }
}
