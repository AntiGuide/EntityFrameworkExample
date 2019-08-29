namespace ClientServer.Repository {
    public interface IGameSessionRepository : IRepository<GameSession> {
        void SetLastCreatedEvent(int sessionId, int eventId);
    }
}
