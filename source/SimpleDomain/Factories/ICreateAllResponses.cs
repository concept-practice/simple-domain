using System.Collections.Generic;
using SimpleDomain.Core;

namespace SimpleDomain.Factories
{
    /// <summary>
    /// Interface used to describe a class that can create a response that contains all objects of a single type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being mapped.</typeparam>
    /// <typeparam name="TResponse">The type of the response being mapped to.</typeparam>
    public interface ICreateAllResponses<in TEntity, out TResponse>
        where TEntity : Entity
        where TResponse : class
    {
        /// <summary>
        /// Converts a list of a type to a specific response type.
        /// </summary>
        /// <param name="entities">An IEnumerable of a type being mapped.</param>
        /// <returns>A response object designated to represent all objects of a type.</returns>
        TResponse AllResponses(IEnumerable<TEntity> entities);
    }
}
