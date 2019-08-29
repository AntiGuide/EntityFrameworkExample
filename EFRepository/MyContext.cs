using ClientServer.Repository;
using System.Data.Entity;

namespace ClientServer.EFRepository {
    /// <summary>Provides a DBContext and DBSets for all tables</summary>
    public class MyContext : DbContext {
        static MyContext() {
            Database.SetInitializer(new MyInitializer());
        }

        /// <summary>Consumer data set</summary>
        public DbSet<Consumer> Consumers { get; set; }

        /// <summary>Event data set</summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>GameSession data set</summary>
        public DbSet<GameSession> GameSessions { get; set; }
    }
}