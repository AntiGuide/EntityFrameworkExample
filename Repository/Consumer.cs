using ClientServer.Common;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ClientServer.Repository {
    /// <summary>A consumer/user of the game</summary>
    public class Consumer : IDisposable {

        /// <summary>Unique database ID used as the primary key.</summary>
        public int Id { get; private set; }

        /// <summary>The reference to all sessions referencing this consumer.</summary>
        public ICollection<GameSession> GameSessions { get; private set; }

        /// <summary>The factory to open channels to the server</summary>
        private ChannelFactory<IEventService> factory;

        /// <summary>Constructor without opening a connection to the server</summary>
        public Consumer(bool clientSide) {

        }

        /// <summary>Constructor is opening a connection to the server</summary>
        public Consumer() {
            OpenChannelFactory();
            OpenChannelAndPerform(svc => Id = svc.CreateConsumer().Id);
        }

        /// <summary>Create the factory with hardcoded settings</summary>
        private void OpenChannelFactory() {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/Event");
            EndpointAddress address = new EndpointAddress(baseAddress);
            NetTcpBinding binding = new NetTcpBinding();
            factory = new ChannelFactory<IEventService>(binding, address);
        }

        /// <summary>
        /// Opens a dedicated channel and performs the passed action
        /// </summary>
        /// <typeparam name="T">The return type of the method</typeparam>
        /// <param name="action">The action that is performed while the channel is open.</param>
        /// <returns>Returns the object returned by the passed action</returns>
        private T OpenChannelAndPerform<T>(Func<IEventService, T> action) {
            IEventService svc = factory.CreateChannel();
            var retValue = action(svc);
            (svc as IChannel).Close();
            return retValue;
        }

        /// <summary>
        /// Creates a GameSession on the connected server
        /// </summary>
        /// <returns>Returns the created GameSession</returns>
        public DTOGameSession CreateGameSession() {
            return OpenChannelAndPerform(svc => svc.CreateSession(Id));
        }

        /// <summary>
        /// Creates an Event on the connected server
        /// </summary>
        /// <param name="eventName">The name that the event will be given</param>
        /// <param name="gameSession">The GameSession that the event occurred in</param>
        /// <returns>Returns the created Event</returns>
        public DTOEvent CreateEvent(string eventName, DTOGameSession gameSession) {
            return OpenChannelAndPerform(svc => svc.CreateEvent(eventName, gameSession.Id));
        }

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetAllEventsOrderedByCountDesc() {
            return OpenChannelAndPerform(svc => svc.GetAllEventsOrderedByCountDesc());
        }

        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="eventName">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetNextEventsOrderedByCountDesc(string eventName) {
            return OpenChannelAndPerform(svc => svc.GetNextEventsOrderedByCountDesc(eventName));
        }

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        public IEnumerable<DTOEventInfo> GetLastEventsOrderedByCountDesc() {
            return OpenChannelAndPerform(svc => svc.GetLastEventsOrderedByCountDesc());
        }

        /// <summary>
        /// Close the factory when consumer is disposed
        /// </summary>
        public void Dispose() {
            factory.Close();
        }
    }
}