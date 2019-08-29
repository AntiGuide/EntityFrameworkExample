using System.Collections.Generic;

namespace ClientServer.Repository {
    /// <summary>A game session a consumer started. Can contain multiple events per session.</summary>
    public class GameSession {

        /// <summary>Unique database ID used as the primary key.</summary>
        public int Id { get; private set; }

        /// <summary>The foreign key of a consumer used to reference the consumer that started the session.</summary>
        public int ConsumerId { get; private set; }

        /// <summary>The reference to all events referencing this session.</summary>
        public ICollection<Event> Events { get; private set; }

        /// <summary>Holds the ID of the last event created if there is one.</summary>
        public int? LastEventId { get; set; }

        /// <summary>Holds the reference to the last event created if there is one.</summary>
        public virtual Event LastEvent { get; set; }

        public GameSession(int consumerId) {
            ConsumerId = consumerId;
        }

        public GameSession() { }
    }
}