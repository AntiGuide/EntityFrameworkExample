using System.Collections.Generic;

namespace ClientServer.Repository {
    /// <summary>
    /// Template for all data repositories
    /// </summary>
    /// <typeparam name="TEntity">Contained data type</typeparam>
    public interface IRepository<TEntity> where TEntity : class {

        /// <summary>Get an object by its ID</summary>
        TEntity GetById(int id);

        /// <summary>Returns all elements</summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>Creates/Registers an element</summary>
        TEntity Create(TEntity entity);
    }
}
