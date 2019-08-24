using ClientServer.Repository;

namespace ClientServer.EFRepository {
    class EFEventRepository : EFRepository<Event>, IEventRepository {
        public EFEventRepository(MyContext ctx) : base(ctx) {

        }
    }
}
