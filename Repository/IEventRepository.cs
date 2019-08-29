using System.Collections.Generic;

namespace ClientServer.Repository {
    public interface IEventRepository : IRepository<Event> {
        IEnumerable<EventInfo> GetAllOrderedByCountDesc();
        IEnumerable<EventInfo> GetNextEventsOrderedByCountDesc(string name);
        IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc();
    }
}
