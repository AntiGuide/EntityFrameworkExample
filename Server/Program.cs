using ClientServer.EFRepository;
using ClientServer.Repository;
using System;

namespace ClientServer.Server {
    class Program {
        static void Main(string[] args) {
            var controller = new EventController(() => new EFSessionScope());
            using (var host = new Host<EFSessionScope>()) {
                host.Start();
                Console.WriteLine("Server gestartet");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
