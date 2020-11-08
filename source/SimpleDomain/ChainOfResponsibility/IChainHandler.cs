using System.Threading.Tasks;

namespace SimpleDomain.ChainOfResponsibility
{
    /// <summary>
    /// An interface used to describe a class which serves as a chain of responsibility handler.
    /// </summary>
    /// <typeparam name="T">The type of the object being sent through the chain.</typeparam>
    public interface IChainHandler<T>
    {
        /// <summary>
        /// Handles a request object and passes it to the next handler in the chain.
        /// </summary>
        /// <param name="request">The request object being handled.</param>
        /// <returns>A <see cref="Task{T}"/>.</returns>
        Task<T> Handle(T request);
    }
}
