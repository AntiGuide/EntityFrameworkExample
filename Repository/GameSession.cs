using System.Collections.Generic;

namespace ClientServer.Repository {
    public class GameSession {
        public int Id { get; set; }

        public int ConsumerId { get; set; }
        public Consumer Consumer { get; set; }

        public ICollection<Event> Events { get; set; }

        public int? LastEventId { get; set; }
        //private Event lastEvent;
        //public Event LastEvent { get { return lastEvent; } set { lastEvent = value; } }
        public virtual Event LastEvent { get; set; }
    }
}