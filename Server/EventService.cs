using ClientServer.Common;
using ClientServer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Server {
    class EventService<T> : IEventService where T : ISessionScope, new() {
        private EventController controller = new EventController(() => new T());

        public DTOConsumer CreateConsumer(string name) {
            return controller.CreateConsumer(name).ToDTO();
        }

        public DTOGameSession CreateSession(int consumerId) {
            return controller.CreateSession(consumerId).ToDTO();
        }

        public DTOEvent CreateEvent(string name, int sessionId) {
            return controller.CreateEvent(name, sessionId).ToDTO();
        }

        public IEnumerable<DTOGameSession> GetSessions() {
            return controller.GetSessions().Select(session => session.ToDTO());
        }

        public IEnumerable<DTOConsumer> GetConsumers() {
            return controller.GetConsumers().Select(consumer => consumer.ToDTO());
        }

        public IEnumerable<DTOEvent> GetEvents() {
            return controller.GetEvents().Select(e => e.ToDTO());
        }
    }
}