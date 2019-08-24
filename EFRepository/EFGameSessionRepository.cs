using ClientServer.Repository;

namespace ClientServer.EFRepository {
    class EFGameSessionRepository : EFRepository<GameSession>, IGameSessionRepository {
        public EFGameSessionRepository(MyContext ctx) : base(ctx) {

        }
    }
}
