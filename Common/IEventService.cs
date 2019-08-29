using System.Collections.Generic;
using System.ServiceModel;

namespace ClientServer.Common {
    /// <summary>The interface for all WCF communication between Server and Client</summary>
    [ServiceContract]
    public interface IEventService {

        /// <summary>Creates and returns Consumer as a DTO object.</summary>
        [OperationContract]
        DTOConsumer CreateConsumer();

        /// <summary>Creates and returns GameSession as a DTO object.</summary>
        [OperationContract]
        DTOGameSession CreateSession(int consumerId);

        /// <summary>Creates and returns Event as a DTO object.</summary>
        [OperationContract]
        DTOEvent CreateEvent(string name, int sessionId);

        /// <summary>Get all Consumers as DTO objects.</summary>
        [OperationContract]
        IEnumerable<DTOConsumer> GetConsumers();

        /// <summary>Get all GameSessions as DTO objects.</summary>
        [OperationContract]
        IEnumerable<DTOGameSession> GetSessions();

        /// <summary>Get all Events as DTO objects.</summary>
        [OperationContract]
        IEnumerable<DTOEvent> GetEvents();

        /// <summary>
        /// Queries all events and their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        [OperationContract]
        IEnumerable<DTOEventInfo> GetAllEventsOrderedByCountDesc();

        /// <summary>
        /// Queries all events that happened after the events with the given name including their counts
        /// </summary>
        /// <param name="name">The event to search for</param>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        [OperationContract]
        IEnumerable<DTOEventInfo> GetNextEventsOrderedByCountDesc(string name);

        /// <summary>
        /// Queries all events that happened as the last event in a sessionincluding their counts
        /// </summary>
        /// <returns>Returns events and their counts ordered by count (descending)</returns>
        [OperationContract]
        IEnumerable<DTOEventInfo> GetLastEventsOrderedByCountDesc();
    }
}
