namespace SimpleDomain.Factories
{
    /// <summary>
    /// Interface used to describe a class that can create a response from a type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being mapped.</typeparam>
    /// <typeparam name="TResponse">The type of the response being mapped to.</typeparam>
    public interface ICreateResponse<in TEntity, out TResponse>
        where TResponse : class
    {
        /// <summary>
        /// Converts a type to a specific response type.
        /// </summary>
        /// <param name="entity">A instance of the typ being mapped.</param>
        /// <returns>A response object.</returns>
        TResponse Response(TEntity entity);
    }
}
