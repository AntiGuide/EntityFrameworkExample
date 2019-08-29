using System.Collections.Generic;

namespace ClientServer.Repository {
    /// <summary>Handles Event specific functions</summary>
    public interface IEventRepository : IRepository<Event> {

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        IEnumerable<EventInfo> GetAllOrderedByCountDesc();

        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="name">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        IEnumerable<EventInfo> GetNextEventsOrderedByCountDesc(string name);

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc();
    }
}
