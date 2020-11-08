using System.Threading.Tasks;

namespace SimpleDomain.Core
{
    /// <summary>
    /// A class to serve as a void for generics.
    /// </summary>
    public sealed class Unit
    {
        /// <summary>
        /// Gets an instance of itself.
        /// </summary>
        public static readonly Unit Value = new Unit();

        /// <summary>
        /// Gets an instance of itself wrapped in a <see cref="Task"/>.
        /// </summary>
        public static readonly Task<Unit> TaskValue = Task.FromResult(Value);
    }
}
