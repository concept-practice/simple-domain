namespace SimpleDomain.Strategy
{
    using System.Threading.Tasks;

    public interface IStrategy<in TIn, TOut>
    {
        Task<TOut> Handle(TIn request);
    }
}
