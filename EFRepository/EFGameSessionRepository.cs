using ClientServer.Repository;

namespace ClientServer.EFRepository {
    class EFGameSessionRepository : EFRepository<GameSession>, IGameSessionRepository {
        public EFGameSessionRepository(MyContext ctx) : base(ctx) {

        }

        public void SetLastCreatedEvent(int sessionId, int eventId) {
            GetById(sessionId).LastEventId = eventId;
            ctx.SaveChanges();
        }
    }
}
