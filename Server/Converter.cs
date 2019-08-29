using ClientServer.Common;
using ClientServer.Repository;

namespace ClientServer.Server {
    /// <summary>Converts various objects to their DTO counterpart</summary>
    public static class Converter {

        /// <summary>Converts this object to its DTO counterpart</summary>
        public static DTOGameSession ToDTO(this GameSession session) {
            return new DTOGameSession() { Id = session.Id };
        }

        /// <summary>Converts this object to its DTO counterpart</summary>
        public static DTOConsumer ToDTO(this Consumer consumer) {
            return new DTOConsumer() { Id = consumer.Id };
        }

        /// <summary>Converts this object to its DTO counterpart</summary>
        public static DTOEvent ToDTO(this Event e) {
            return new DTOEvent() { Id = e.Id, Name = e.Name };
        }

        /// <summary>Converts this object to its DTO counterpart</summary>
        public static DTOEventInfo ToDTO(this EventInfo e) {
            return new DTOEventInfo() { EventName = e.Name, Count = e.Count};
        }
    }
}
