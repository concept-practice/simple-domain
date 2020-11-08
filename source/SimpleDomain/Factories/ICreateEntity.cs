namespace SimpleDomain.Factories
{
    /// <summary>
    /// Interface used to describe a class that can create an entity from a request object.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ICreateEntity<in TRequest, out TEntity>
    {
        /// <summary>
        /// Converts a request object into an entity.
        /// </summary>
        /// <param name="request">A request of type TRequest.</param>
        /// <returns>An entity of type TEntity.</returns>
        TEntity Entity(TRequest request);
    }
}