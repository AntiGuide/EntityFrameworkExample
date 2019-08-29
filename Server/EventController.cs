using ClientServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Server {
    public delegate ISessionScope Factory();

    public class EventController {
        private Factory factory;

        public EventController(Factory factory) {
            this.factory = factory;
        }

        public Consumer CreateConsumer() {
            using (var scope = factory.Invoke()) {
                var consumer = new Consumer(false);
                consumer = scope.ConsumerRepository.Create(consumer);
                Console.WriteLine("Consumer with ID " + consumer.Id + " and Name \"" + consumer.Name + "\" created.");
                return consumer;
            }
        }

        public GameSession CreateSession(int consumerId) {
            using (var scope = factory.Invoke()) {
                var session = new GameSession { ConsumerId = consumerId };
                session = scope.GameSessionRepository.Create(session);
                Console.WriteLine("Session with ID " + session.Id + " created.");
                return session;
            }
        }

        public Event CreateEvent(string name, int sessionId) {
            using (var scope = factory.Invoke()) {
                var e = new Event { Name = name, GameSessionId = sessionId };
                e = scope.EventRepository.Create(e);
                var session = scope.GameSessionRepository.GetById(sessionId);
                if (session.LastEvent != null) {
                    session.LastEvent.NextEventId = e.Id;
                    session.LastEvent.NextEvent = e;
                }

                scope.GameSessionRepository.SetLastCreatedEvent(sessionId, e.Id);
                Console.WriteLine("Event with ID " + e.Id + " and Name \"" + e.Name + "\" created.");
                return e;
            }
        }

        public IEnumerable<GameSession> GetSessions() {
            using (var scope = factory.Invoke()) {
                return scope.GameSessionRepository.GetAll();
            }
        }

        public IEnumerable<Consumer> GetConsumers() {
            using (var scope = factory.Invoke()) {
                return scope.ConsumerRepository.GetAll();
            }
        }

        public IEnumerable<Event> GetEvents() {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetAll();
            }
        }

        public IEnumerable<EventInfo> GetAllEventsOrderedByCountDesc() {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetAllOrderedByCountDesc();
            }
        }

        public IEnumerable<EventInfo> GetNextEventsOrderedByCountDesc(string name) {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetNextEventsOrderedByCountDesc(name);
            }
        }

        public IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc() {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetLastEventsOrderedByCountDesc();
            }
        }
    }
}