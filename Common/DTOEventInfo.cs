namespace ClientServer.Common {
    /// <summary>Used to return info about occurrences of events (DTO variant)</summary>
    public class DTOEventInfo {

        /// <summary>Name of the event</summary>
        public string EventName { get; set; }

        /// <summary>Amount of times the event has been triggered</summary>
        public int Count { get; set; }
    }
}