using System;

namespace ClientServer.Repository {
    public class Event {
        public int Id { get; set; }

        public int Count { get; set; }
        public string Name { get; set; }

        public int GameSessionId { get; set; }
        public GameSession GameSession { get; set; }

        //public Event PreviousEvent { get; set; }
        //public int PreviousEventCountInSession { get; set; }
        //public DateTime Timestamp { get; set; }
    }
}