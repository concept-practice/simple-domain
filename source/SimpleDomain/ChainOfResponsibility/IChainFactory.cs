namespace SimpleDomain.ChainOfResponsibility
{
    /// <summary>
    /// An interface used to describe a class to service as a factory for a chain of responsibility.
    /// </summary>
    /// <typeparam name="T">The type of the request the chain will handle.</typeparam>
    public interface IChainFactory<T>
    {
        /// <summary>
        /// Returns <see cref="IChainHandler{T}"/> that will serve as the starting point for a chain of responsibility.
        /// </summary>
        /// <returns>A <see cref="IChainHandler{T}"/>.</returns>
        IChainHandler<T> CreateChain();
    }
}
