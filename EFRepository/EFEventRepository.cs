using System.Collections.Generic;
using System.Linq;
using ClientServer.Repository;

namespace ClientServer.EFRepository {
    /// <summary>Handles Event specific functions</summary>
    class EFEventRepository : EFRepository<Event>, IEventRepository {
        public EFEventRepository(MyContext ctx) : base(ctx) {

        }

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetAllOrderedByCountDesc() {
            return ctx.Events
                .GroupBy(
                e => e.Name,
                e => e.Name,
                (key, g) => new EventInfo { Name = key, Count = g.Count() }).OrderByDescending(a => a.Count).ToList();
        }

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc() {
            var ret = ctx.Events
                .Where(e => e.NextEvent == null)
                .GroupBy(
                e => e.Name,
                e => e.Name,
                (key, g) => new EventInfo { Name = key, Count = g.Count() }).OrderByDescending(a => a.Count).ToList();
            return ret;
        }
        
        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="name">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetNextEventsOrderedByCountDesc(string name) {
            return ctx.Events
                .Where(e => e.Name == name && e.NextEvent != null)
                .Select(e => e.NextEvent)
                .GroupBy(
                e => e.Name,
                e => e.Name,
                (key, g) => new EventInfo { Name = key, Count = g.Count() }).OrderByDescending(a => a.Count).ToList();
        }
    }
}
