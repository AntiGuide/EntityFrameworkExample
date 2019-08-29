using ClientServer.Common;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Linq;

namespace ClientServer.Repository {
    public class Consumer : IDisposable {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GameSession> GameSessions { get; set; }

        private ChannelFactory<IEventService> factory;

        public Consumer(bool clientSide = true) {
            if (!clientSide) return;

            Uri baseAddress = new Uri("net.tcp://localhost:8009/Event");
            EndpointAddress address = new EndpointAddress(baseAddress);
            NetTcpBinding binding = new NetTcpBinding();
            factory = new ChannelFactory<IEventService>(binding, address);
            IEventService svc = factory.CreateChannel();
            Id = svc.CreateConsumer().Id;
            (svc as IChannel).Close();
        }

        public DTOGameSession CreateGameSession() {
            IEventService svc = factory.CreateChannel();
            var retVal = svc.CreateSession(Id);
            (svc as IChannel).Close();
            return retVal;
        }

        public DTOEvent CreateEvent(string eventName, DTOGameSession gameSession) {
            IEventService svc = factory.CreateChannel();
            var retVal = svc.CreateEvent(eventName, gameSession.Id);
            (svc as IChannel).Close();
            return retVal;
        }

        public IEnumerable<DTOEventInfo> GetAllEventsOrderedByCountDesc() {
            IEventService svc = factory.CreateChannel();
            var retVal = svc.GetAllEventsOrderedByCountDesc();
            (svc as IChannel).Close();
            return retVal;
        }

        public IEnumerable<DTOEventInfo> GetNextEventsOrderedByCountDesc(string eventName) {
            IEventService svc = factory.CreateChannel();
            var retVal = svc.GetNextEventsOrderedByCountDesc(eventName);
            (svc as IChannel).Close();
            return retVal;
        }

        public IEnumerable<DTOEventInfo> GetLastEventsOrderedByCountDesc() {
            IEventService svc = factory.CreateChannel();
            var retVal = svc.GetLastEventsOrderedByCountDesc();
            (svc as IChannel).Close();
            return retVal;
        }

        public void Dispose() {
            factory.Close();
        }
    }
}