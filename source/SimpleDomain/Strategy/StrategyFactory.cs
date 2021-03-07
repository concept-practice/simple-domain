namespace SimpleDomain.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class StrategyFactory<TIn, TOut> : IStrategyFactory<TIn, TOut>
    {
        public IStrategy<TIn, TOut> ResolveStrategy(TIn request)
        {
            return AddStrategies().First(keyValuePair => keyValuePair.Key.Invoke(request)).Value;
        }

        protected abstract IDictionary<Func<TIn, bool>, IStrategy<TIn, TOut>> AddStrategies();
    }
}
