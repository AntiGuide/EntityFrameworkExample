namespace ClientServer.Repository {
    /// <summary>Handles GameSession specific functions</summary>
    public interface IGameSessionRepository : IRepository<GameSession> {

        /// <summary>
        /// Save the most recently created Event
        /// </summary>
        /// <param name="sessionId">The GameSession the Event belongs to</param>
        /// <param name="eventId">The EventId to save in the GameSession</param>
        void SetLastCreatedEvent(int sessionId, int eventId);
    }
}
