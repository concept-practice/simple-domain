using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDomain.Strategy
{
    /// <summary>
    /// A base class for <see cref="IStrategyFactory{TIn,TOut}"/> that will resolve an <see cref="IStrategy{TIn,TOut}"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of the request object.</typeparam>
    /// <typeparam name="TOut">The type of the response object.</typeparam>
    public abstract class StrategyFactory<TIn, TOut> : IStrategyFactory<TIn, TOut>
    {
        /// <summary>
        /// Resolves an <see cref="IStrategy{TIn,TOut}"/> appropriate for the request.
        /// </summary>
        /// <param name="request">The request for a strategy to be resolved.</param>
        /// <returns>An <see cref="IStrategy{TIn,TOut}"/>.</returns>
        public IStrategy<TIn, TOut> ResolveStrategy(TIn request)
        {
            return AddStrategies().First(keyValuePair => keyValuePair.Key.Invoke(request)).Value;
        }

        /// <summary>
        /// An abstract method to be implemented by a derived class to add strategies.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey,TValue}"/>.</returns>
        protected abstract IDictionary<Func<TIn, bool>, IStrategy<TIn, TOut>> AddStrategies();
    }
}
