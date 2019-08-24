using ClientServer.Repository;

namespace ClientServer.EFRepository {
    class EFConsumerRepository : EFRepository<Consumer>, IConsumerRepository {
        public EFConsumerRepository(MyContext ctx) : base(ctx) {

        }
    }
}
