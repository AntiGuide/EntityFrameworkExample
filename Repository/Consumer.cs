using System;
using System.Collections.Generic;

namespace ClientServer.Repository {
    public class Consumer : IDisposable {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GameSession> GameSessions { get; set; }

        public GameSession CreateGameSession() {
            return new GameSession();
        }

        public void CreateEvent(string eventName, GameSession gameSession) {
            throw new NotImplementedException();
        }

        public Event[] GetAllEventsOrderedByCountDesc() {
            throw new NotImplementedException();
        }

        public Event[] GetNextEventsOrderedByCountDesc(string eventName) {
            throw new NotImplementedException();
        }

        public Event[] GetLastEventsOrderedByCountDesc() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}