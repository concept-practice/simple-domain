namespace SimpleDomain.ChainOfResponsibility
{
    using System.Threading.Tasks;

    public interface IChainHandler<T>
    {
        Task<T> Handle(T request);
    }
}
