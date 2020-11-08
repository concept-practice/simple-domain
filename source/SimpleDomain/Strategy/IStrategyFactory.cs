namespace SimpleDomain.Strategy
{
    /// <summary>
    /// An interface used to describe a factory class that will return an <see cref="IStrategy{TIn,TOut}"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of the request object.</typeparam>
    /// <typeparam name="TOut">The type of the result object.</typeparam>
    public interface IStrategyFactory<in TIn, TOut>
    {
        /// <summary>
        /// Resolves a <see cref="IStrategy{TIn,TOut}"/> from a request.
        /// </summary>
        /// <param name="request">The request to be resolved.</param>
        /// <returns>A <see cref="IStrategy{TIn,TOut}"/>.</returns>
        IStrategy<TIn, TOut> ResolveStrategy(TIn request);
    }
}
