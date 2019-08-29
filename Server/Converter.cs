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
            return new DTOEvent() { Id = e.Id, Name = e.Name };
        }

        public static DTOEventInfo ToDTO(this EventInfo e) {
            return new DTOEventInfo() { Name = e.Name, Count = e.Count};
        }

        public static GameSession ToPOCO(this DTOGameSession session) {
            return new GameSession() { Id = session.Id };
        }

        public static Consumer ToPOCO(this DTOConsumer consumer) {
            return new Consumer(false) { Id = consumer.Id, Name = consumer.Name };
        }

        public static Event ToPOCO(this DTOEvent e) {
            return new Event() { Id = e.Id, Name = e.Name };
        }
    }
}
