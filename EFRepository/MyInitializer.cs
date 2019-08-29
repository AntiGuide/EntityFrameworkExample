using System.Data.Entity;

namespace ClientServer.EFRepository {
    /// <summary>Initializes DB for EntityFramework (Dropped every time during development => Change in production)</summary>
    class MyInitializer : DropCreateDatabaseAlways<MyContext> {

    }
}