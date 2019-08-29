using ClientServer.Common;
using ClientServer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Server {
    class EventService<T> : IEventService where T : ISessionScope, new() {
        private EventController controller = new EventController(() => new T());

        /// <summary>Creates and returns Consumer as a DTO object.</summary>
        public DTOConsumer CreateConsumer() {
            return controller.CreateConsumer().ToDTO();
        }

        /// <summary>Creates and returns GameSession as a DTO object.</summary>
        public DTOGameSession CreateSession(int consumerId) {
            return controller.CreateSession(consumerId).ToDTO();
        }

        /// <summary>Creates and returns Event as a DTO object.</summary>
        public DTOEvent CreateEvent(string name, int sessionId) {
            return controller.CreateEvent(name, sessionId).ToDTO();
        }

        /// <summary>Get all GameSessions as DTO objects.</summary>
        public IEnumerable<DTOGameSession> GetSessions() {
            return controller.GetSessions().Select(session => session.ToDTO());
        }

        /// <summary>Get all Consumers as DTO objects.</summary>
        public IEnumerable<DTOConsumer> GetConsumers() {
            return controller.GetConsumers().Select(consumer => consumer.ToDTO());
        }

        /// <summary>Get all Events as DTO objects.</summary>
        public IEnumerable<DTOEvent> GetEvents() {
            return controller.GetEvents().Select(e => e.ToDTO());
        }

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetAllEventsOrderedByCountDesc() {
            return controller.GetAllEventsOrderedByCountDesc().Select(e => e.ToDTO());
        }

        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="name">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetNextEventsOrderedByCountDesc(string name) {
            return controller.GetNextEventsOrderedByCountDesc(name).Select(e => e.ToDTO());
        }

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetLastEventsOrderedByCountDesc() {
            return controller.GetLastEventsOrderedByCountDesc().Select(e => e.ToDTO());
        }
    }
}