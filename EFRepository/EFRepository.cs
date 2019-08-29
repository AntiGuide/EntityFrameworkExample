using System.Collections.Generic;
using ClientServer.Repository;
using System.Linq;

namespace ClientServer.EFRepository {
    /// <summary>Template for all data repositories.</summary>
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected MyContext ctx;

        /// <summary>Initialize repository with DBContext</summary>
        public EFRepository(MyContext ctx) {
            this.ctx = ctx;
        }

        /// <summary>Creates/Registers an element</summary>
        public TEntity Create(TEntity entity) {
            var ret = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return ret;
        }

        /// <summary>Returns all elements</summary>
        public IEnumerable<TEntity> GetAll() {
            return ctx.Set<TEntity>().ToList();
        }

        /// <summary>Get an object by its ID</summary>
        public TEntity GetById(int id) {
            return ctx.Set<TEntity>().Find(id);
        }
    }
}