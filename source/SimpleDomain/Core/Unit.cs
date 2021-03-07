namespace SimpleDomain.Core
{
    using System.Threading.Tasks;

    public sealed class Unit
    {
        public static readonly Unit Value = new Unit();

        public static readonly Task<Unit> TaskValue = Task.FromResult(Value);
    }
}
