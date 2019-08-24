using System.Collections.Generic;

namespace ClientServer.Repository {
    public class GameSession {
        public int Id { get; set; }

        public int ConsumerId { get; set; }
        public Consumer Consumer { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}