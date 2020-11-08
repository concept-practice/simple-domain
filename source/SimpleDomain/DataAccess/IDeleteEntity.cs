using System;
using System.Threading.Tasks;

namespace SimpleDomain.DataAccess
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity.
    /// </summary>
    public interface IDeleteEntity
    {
        /// <summary>
        /// Removes an entity from a collection by its GUID.
        /// </summary>
        /// <param name="id">The GUID of the entity.</param>
        /// <returns>A Task object.</returns>
        Task DeleteEntity(Guid id);
    }
}
