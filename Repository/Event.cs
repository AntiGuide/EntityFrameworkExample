namespace ClientServer.Repository {
    /// <summary>A single event that ocurred during a game session</summary>
    public class Event {

        /// <summary>Unique database ID used as the primary key.</summary>
        public int Id { get; private set; }

        /// <summary>The events name</summary>
        public string Name { get; private set; }

        /// <summary>The foreign key of a game session used to reference the session that the event occurred in.</summary>
        public int GameSessionId { get; private set; }

        /// <summary>Holds the ID of the event that happend next in the session if there is one.</summary>
        public int? NextEventId { get; set; }

        /// <summary>Holds the reference to the event that happend next in the session if there is one.</summary>
        public virtual Event NextEvent { get; set; }

        public Event(string name, int gameSessionId) {
            Name = name;
            GameSessionId = gameSessionId;
        }

        public Event() { }
    }
}