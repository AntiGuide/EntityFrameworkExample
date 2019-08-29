using ClientServer.Repository;
using System;
using System.Collections.Generic;

namespace ClientServer.Server {
    /// <summary>
    /// Delegate for ISessionScope creation.
    /// </summary>
    /// <returns>Created ISessionScope</returns>
    public delegate ISessionScope Factory();

    public class EventController {
        /// <summary>Delegate for ISessionScope creation.</summary>
        private Factory factory;

        /// <summary>
        /// Introduces delegate for ISessionScope creation.
        /// </summary>
        /// <param name="factory">Delegate for ISessionScope creation.</param>
        public EventController(Factory factory) {
            this.factory = factory;
        }

        /// <summary>
        /// Opens a dedicated ISessionScope and performs the passed action
        /// </summary>
        /// <typeparam name="T">The return type of the method</typeparam>
        /// <param name="action">The action that is performed while the channel is open.</param>
        /// <returns>Returns the object returned by the passed action</returns>
        private T OpenContextAndPerform<T>(Func<ISessionScope, T> action) {
            using (var scope = factory.Invoke()) {
                var ret = action(scope);
                return ret;
            }
        }

        /// <summary>Creates and returns Consumer</summary>
        public Consumer CreateConsumer() {
            return OpenContextAndPerform(s => s.ConsumerRepository.Create(new Consumer(false)));
        }

        /// <summary>Creates and returns GameSession</summary>
        public GameSession CreateSession(int consumerId) {
            return OpenContextAndPerform(s => s.GameSessionRepository.Create(new GameSession(consumerId)));
        }

        /// <summary>Creates and returns Event</summary>
        public Event CreateEvent(string name, int sessionId) {
            return OpenContextAndPerform(s => {
                var e = s.EventRepository.Create(new Event(name, sessionId));
                var lastEvent = s.GameSessionRepository.GetById(sessionId)?.LastEvent;
                if (lastEvent != null) {
                    lastEvent.NextEventId = e.Id;
                    lastEvent.NextEvent = e;
                }

                s.GameSessionRepository.SetLastCreatedEvent(sessionId, e.Id);
                return e;
            });
        }

        /// <summary>Get all GameSessions.</summary>
        public IEnumerable<GameSession> GetSessions() {
            return OpenContextAndPerform(s => s.GameSessionRepository.GetAll());
        }

        /// <summary>Get all Consumers.</summary>
        public IEnumerable<Consumer> GetConsumers() {
            return OpenContextAndPerform(s => s.ConsumerRepository.GetAll());
        }

        /// <summary>Get all Events.</summary>
        public IEnumerable<Event> GetEvents() {
            return OpenContextAndPerform(s => s.EventRepository.GetAll());
        }

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetAllEventsOrderedByCountDesc() {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetAllOrderedByCountDesc();
            }
        }

        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="eventName">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetNextEventsOrderedByCountDesc(string name) {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetNextEventsOrderedByCountDesc(name);
            }
        }

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<EventInfo> GetLastEventsOrderedByCountDesc() {
            using (var scope = factory.Invoke()) {
                return scope.EventRepository.GetLastEventsOrderedByCountDesc();
            }
        }
    }
}