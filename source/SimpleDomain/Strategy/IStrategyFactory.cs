namespace SimpleDomain.Strategy
{
    public interface IStrategyFactory<in TIn, TOut>
    {
        IStrategy<TIn, TOut> ResolveStrategy(TIn request);
    }
}
