namespace ClientServer.Common {
    /// <summary>A single event that ocurred during a game session (DTO variant)</summary>
    public class DTOEvent {

        /// <summary>Unique database ID used as the primary key.</summary>
        public int Id { get; set; }

        /// <summary>The events name</summary>
        public string Name { get; set; }
    }
}
