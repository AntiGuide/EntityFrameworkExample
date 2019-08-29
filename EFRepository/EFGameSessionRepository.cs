using ClientServer.Repository;

namespace ClientServer.EFRepository {
    /// <summary>Handles GameSession specific functions</summary>
    class EFGameSessionRepository : EFRepository<GameSession>, IGameSessionRepository {
        public EFGameSessionRepository(MyContext ctx) : base(ctx) {

        }

        /// <summary>
        /// Save the most recently created Event
        /// </summary>
        /// <param name="sessionId">The GameSession the Event belongs to</param>
        /// <param name="eventId">The EventId to save in the GameSession</param>
        public void SetLastCreatedEvent(int sessionId, int eventId) {
            GetById(sessionId).LastEventId = eventId;
            ctx.SaveChanges();
        }
    }
}
