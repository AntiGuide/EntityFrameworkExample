using ClientServer.Common;
using ClientServer.Repository;

namespace ClientServer.Server {
    public static class Converter {
        public static DTOGameSession ToDTO(this GameSession session) {
            return new DTOGameSession() { Id = session.Id };
        }

        public static DTOConsumer ToDTO(this Consumer consumer) {
            return new DTOConsumer() { Id = consumer.Id, Name = consumer.Name };
        }

        public static DTOEvent ToDTO(this Event e) {
            return new DTOEvent() { Id = e.Id, EventName = e.Name };
        }
    }
}
