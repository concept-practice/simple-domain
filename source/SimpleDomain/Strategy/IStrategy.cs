using System.Threading.Tasks;

namespace SimpleDomain.Strategy
{
    /// <summary>
    /// An interface used to describe a strategy class that will accept a request and return a result.
    /// </summary>
    /// <typeparam name="TIn">The type of the request object.</typeparam>
    /// <typeparam name="TOut">The type of the result object.</typeparam>
    public interface IStrategy<in TIn, TOut>
    {
        /// <summary>
        /// Handles a request and returns the result.
        /// </summary>
        /// <param name="request">The request object to be handled.</param>
        /// <returns>A <see cref="Task{TOut}"/>.</returns>
        Task<TOut> Handle(TIn request);
    }
}
