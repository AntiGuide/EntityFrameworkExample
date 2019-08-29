using System;

namespace ClientServer.Repository {
    public class Event {
        public int Id { get; set; }

        //public int Count { get; set; }
        public string Name { get; set; }

        public int GameSessionId { get; set; }
        public GameSession GameSession { get; set; }

        public int? NextEventId { get; set; }
        public virtual Event NextEvent { get; set; }

        //public int? PrevEventId { get; set; }
        //public virtual Event PrevEvent { get; set; }
    }
}