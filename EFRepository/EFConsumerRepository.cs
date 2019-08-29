using ClientServer.Repository;

namespace ClientServer.EFRepository {
    /// <summary>Handles Consumer specific functions</summary>
    class EFConsumerRepository : EFRepository<Consumer>, IConsumerRepository {
        public EFConsumerRepository(MyContext ctx) : base(ctx) {

        }
    }
}
