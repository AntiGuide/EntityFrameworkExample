using ClientServer.Repository;
using System;
using System.Data.Entity;

namespace ClientServer.EFRepository {
    public class MyContext : DbContext {
        static MyContext() {
            Database.SetInitializer<MyContext>(new MyInitializer());
        }

        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
    }
}