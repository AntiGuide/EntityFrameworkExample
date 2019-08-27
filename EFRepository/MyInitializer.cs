using ClientServer.Repository;
using System.Data.Entity;

namespace ClientServer.EFRepository {
    class MyInitializer : DropCreateDatabaseAlways<MyContext> {
        protected override void Seed(MyContext ctx) {
            base.Seed(ctx);
        }
    }
}