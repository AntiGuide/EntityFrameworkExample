using System.Collections.Generic;
using System.ServiceModel;

namespace ClientServer.Common {
    [ServiceContract]
    public interface IEventService {
        [OperationContract]
        DTOConsumer CreateConsumer();

        [OperationContract]
        DTOGameSession CreateSession(int consumerId);

        [OperationContract]
        DTOEvent CreateEvent(string name, int sessionId);

        [OperationContract]
        IEnumerable<DTOConsumer> GetConsumers();

        [OperationContract]
        IEnumerable<DTOGameSession> GetSessions();

        [OperationContract]
        IEnumerable<DTOEvent> GetEvents();

        [OperationContract]
        IEnumerable<DTOEventInfo> GetAllEventsOrderedByCountDesc();

        [OperationContract]
        IEnumerable<DTOEventInfo> GetNextEventsOrderedByCountDesc(string name);

        [OperationContract]
        IEnumerable<DTOEventInfo> GetLastEventsOrderedByCountDesc();
    }
}
