using ClientServer.EFRepository;
using System;

namespace ClientServer.Server {
    /// <summary>Starts the server and leaves it running until a key is pressed.</summary>
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
