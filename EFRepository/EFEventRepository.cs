using System.Collections.Generic;
using System.Linq;
using ClientServer.Repository;

namespace ClientServer.EFRepository {
    class EFEventRepository : EFRepository<Event>, IEventRepository {
        public EFEventRepository(MyContext ctx) : base(ctx) {

        }

        public IEnumerable<EventInfo> GetAllOrderedByCountDesc() {
            return ctx.Events
                .GroupBy(
                e => e.Name,
                e => e.Name,
                (key, g) => new EventInfo { Name = key, Count = g.Count() }).OrderByDescending(a => a.Count).ToList();
        }

        public IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc() {
            var ret = ctx.Events
                .Where(e => e.NextEvent == null)
                .GroupBy(
                e => e.Name,
                e => e.Name,
                (key, g) => new EventInfo { Name = key, Count = g.Count() }).OrderByDescending(a => a.Count).ToList();
            return ret;
        }

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
