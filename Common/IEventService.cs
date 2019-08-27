using ClientServer.Repository;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClientServer.Common {
    [ServiceContract]
    public interface IEventService {
        [OperationContract]
        DTOConsumer CreateConsumer(string name);

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
    }
}
