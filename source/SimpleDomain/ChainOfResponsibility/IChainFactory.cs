namespace SimpleDomain.ChainOfResponsibility
{
    public interface IChainFactory<T>
    {
        IChainHandler<T> CreateChain();
    }
}
