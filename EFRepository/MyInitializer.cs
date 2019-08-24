using ClientServer.Repository;
using System.Data.Entity;

namespace ClientServer.EFRepository {
    class MyInitializer : DropCreateDatabaseAlways<MyContext> {
        protected override void Seed(MyContext ctx) {
            base.Seed(ctx);

            Consumer[] consumers = {    new Consumer { Name = "Lukas" },
                                        new Consumer { Name = "Alice" },
                                        new Consumer { Name = "Bob" }};
            ctx.Consumers.AddRange(consumers);

            GameSession[] gameSessions = { new GameSession { Consumer = consumers[0] } };
            ctx.GameSessions.AddRange(gameSessions);

            Event[] events = { new Event { EventName = "Began Mission 1", Count = 0 } };
            ctx.Events.AddRange(events);

            //gameSessions[0].Events.Add(events[0]);

            ctx.SaveChanges();
        }
    }
}