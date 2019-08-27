using System.Collections.Generic;
using ClientServer.Repository;
using System.Linq;

namespace ClientServer.EFRepository {
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected MyContext ctx;

        public EFRepository(MyContext ctx) {
            this.ctx = ctx;
        }

        public TEntity Create(TEntity entity) {
            var ret = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return ret;
        }

        public IEnumerable<TEntity> GetAll() {
            return ctx.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id) {
            return ctx.Set<TEntity>().Find(id);
        }
    }
}